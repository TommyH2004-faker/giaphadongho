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
using GiaPha_Application.Service;
using GiaPha_Infrastructure.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TodoApp.Application.Service;

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
builder.Services.AddScoped<IChiHoRepository, ChiHoRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IThanhVienRepository, ThanhVienRepository>();
builder.Services.AddScoped<IAuditLogRepository, AuditReopository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
#endregion

#region MediatR + Pipeline + Validation
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateHoCommand).Assembly);
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(typeof(CreateHoCommand).Assembly);
#endregion
//  JWT Service
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IEmailService, SmtpEmailService>();
builder.Services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();


//  JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]!))
    };
});
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();
