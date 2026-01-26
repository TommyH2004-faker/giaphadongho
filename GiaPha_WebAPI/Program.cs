using Microsoft.OpenApi.Models;
using FluentValidation;
using GiaPha_Application.Features.HoName.Command.CreateHo;
using GiaPha_Application.Repository;
using GiaPha_Infrastructure.Db;
using GiaPha_Infrastructure.Repository;
using GiaPha_WebAPI.Filters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Behaviors;

var builder = WebApplication.CreateBuilder(args);

#region Controllers + Filters
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});
#endregion


#region Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "GiaPha API",
        Version = "v1"
    });
});
#endregion

#region Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DbGiaPha>(options =>
{
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(8, 0, 29))
    );
});
#endregion

#region Repositories
builder.Services.AddScoped<IHoRepository, HoRepository>();
#endregion

#region MediatR + Pipeline + Validation
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateHoCommand).Assembly);
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(typeof(CreateHoCommand).Assembly);
#endregion

#region CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontendApp", policy =>
    {
        policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
#endregion

builder.Services.AddAuthorization();

var app = builder.Build();

#region Middleware Pipeline

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GiaPha API v1");
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontendApp");

app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();
