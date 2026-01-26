using FluentValidation;
using GiaPha_Infrastructure.Db;
using GiaPha_WebAPI.Filters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Behaviors;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình mysql connection

var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DbGiaPha>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);


builder.Services.AddAuthorization();
//  MediatR - CQRS Pattern + Domain Events
// ở đây đăng ký các handlers từ assembly Application 
// nó sẽ tự đăng ký tất cả các command, query handlers VÀ event handlers


//  FluentValidation
// Tự động đăng ký tất cả các validator từ assembly Application
// builder.Services.AddValidatorsFromAssembly(typeof(TodoApp.Application.Features.BookHandle.Command.CreateBookCommand).Assembly);

// Add GlobalFilters and Services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.Run();

