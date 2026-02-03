
using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using GiaPha_Application.Repository;
using GiaPha_Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GiaPha_Application.Features.Auth.Command.Register;
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<UserResponse>>
{
    private readonly IAuthRepository authRepository;
    private readonly ILogger<RegisterCommandHandler> _logger;

    public RegisterCommandHandler(IAuthRepository authRepository , ILogger<RegisterCommandHandler> logger)
    {
        this.authRepository = authRepository;
        _logger = logger;
    }

    public async Task<Result<UserResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
         // Kiểm tra email đã tồn tại chưa
            var existingUserByEmail = await authRepository.GetUserByEmailAsync(request.Email);
            if (existingUserByEmail.Data != null)
            {
                throw new InvalidOperationException("Email already exists");
            }

            // Kiểm tra username đã tồn tại chưa
            var existingUserByUsername = await authRepository.GetEmailByUsernameAsync(request.TenDangNhap);
            if (existingUserByUsername.Data != null)
            {
                throw new InvalidOperationException("Username already exists");
            }

            // Hash password với BCrypt
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.MatKhau);

            var newUser = TaiKhoanNguoiDung.Register(
                TenDangNhap: request.TenDangNhap,
                email: request.Email,
                MatKhauMaHoa: hashedPassword, 
                SoDienThoai: request.SoDienThoai,
                gioiTinh: request.GioiTinh ?? GiaPha_Domain.Enums.GioiTinh.Khac,
                role: "User"
            );

            // Lưu vào database
            await authRepository.AddUserAsync(newUser);
            
            //  Raise event SAU khi đã lưu (có IdUser)
            newUser.RaiseRegisteredEvent();
            await authRepository.SaveChangesAsync();
            _logger.LogInformation("Đã lưu notification hệ thống khi tạo thành viên mới.");
            return Result<UserResponse>.Success(
                new UserResponse
                {
                Id = newUser.Id,
                TenDangNhap = newUser.TenDangNhap,
                Email = newUser.Email,
                Role = newUser.Role,
                Enabled = newUser.Enabled,
                MatKhauMaHoa = newUser.MatKhauMaHoa,
                SoDienThoai = newUser.SoDienThoai
                });
    }
}