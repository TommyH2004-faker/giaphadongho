# API 
dotnet add package Swashbuckle.AspNetCore

dotnet add package FluentValidation
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.0

dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.0

dotnet add package Swashbuckle.AspNetCore
# Application Layer
dotnet add package BCrypt.Net-Next
dotnet add package FluentValidation
dotnet add package FluentValidation.AspNetCore
dotnet add package MediatR --version 11.1.0
dotnet add package MediatR.Extensions.Microsoft.DependencyInjection 

# Infras 
dotnet add package Pomelo.EntityFrameworkCore.MySql
dotnet add package SendGrid
dotnet add package System.IdentityModel.Tokens.Jwt

dotnet add package Microsoft.EntityFrameworkCore --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version .0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.0

# Add reference giữa các layer (chuẩn Clean Architecture)
dotnet add GiaPha_WebAPI reference GiaPha_Application

dotnet add GiaPha_Application reference GiaPha_Domain

dotnet add GiaPha_Infrastructure reference GiaPha_Application
dotnet add GiaPha_Infrastructure reference GiaPha_Domain

dotnet add GiaPha_WebAPI reference GiaPha_Infrastructure

# migrations
dotnet ef migrations remove --startup-project ../GiaPha_WebAPI
dotnet ef migrations add InitialCreate --startup-project ../GiaPha_WebAPI
dotnet ef migrations add fixDatabase --startup-project ../GiaPha_WebAPI
dotnet ef migrations add fixDatabaseNew --startup-project ../GiaPha_WebAPI
dotnet ef migrations add fixDatabaseEnums --startup-project ../GiaPha_WebAPI
dotnet ef migrations add fixDatabaseThanhVien --startup-project ../GiaPha_WebAPI
dotnet ef migrations add fixDatabaseAudit --startup-project ../GiaPha_WebAPI
dotnet ef database update --startup-project ../GiaPha_WebAPI
# chuyển hết về net 8.0 rồi sau đó chạy 
dotnet clean
dotnet restore
dotnet build
dotnet ef migrations add Notification --startup-project ../GiaPha_WebAPI