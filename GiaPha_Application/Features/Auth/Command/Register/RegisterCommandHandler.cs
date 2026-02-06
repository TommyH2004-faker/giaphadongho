
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
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCommandHandler(IAuthRepository authRepository , ILogger<RegisterCommandHandler> logger, IUnitOfWork unitOfWork)
    {
        this.authRepository = authRepository;
        _logger = logger;
        _unitOfWork = unitOfWork;
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
            var existingUserByUsername = await authRepository.GetUserByUsernameAsync(request.TenDangNhap);
            if (existingUserByUsername.Data != null)
            {
                throw new InvalidOperationException("Username already exists");
            }

            // Hash password với BCrypt
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.MatKhau);



            var newUser = TaiKhoanNguoiDung.Register(
                request.TenDangNhap,
                request.Email,
                request.GioiTinh,
                hashedPassword,
                request.SoDienThoai,
                "User" 
            );

            // Lưu vào database
            await authRepository.AddUserAsync(newUser);
            
            _logger.LogInformation("🔍 [Handler] Entity có {Count} domain events trước khi save", newUser.DomainEvents.Count);
            
            // Domain Event sẽ tự động được dispatch trong SaveChangesAsync()
            _logger.LogInformation("💾 [Handler] Gọi UnitOfWork.SaveChangesAsync()...");
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation("✅ [Handler] Đã lưu notification hệ thống khi tạo thành viên mới.");
            return Result<UserResponse>.Success(
                new UserResponse
                {
                Id = newUser.Id,
                TenDangNhap = newUser.TenDangNhap,
                Email = newUser.Email,
                Role = newUser.Role,
                Enabled = newUser.Enabled,
                MatKhauMaHoa = newUser.MatKhau,
                SoDienThoai = newUser.SoDienThoai
                });
    }
}