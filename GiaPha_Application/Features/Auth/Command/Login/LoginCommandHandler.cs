using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using GiaPha_Application.Repository;
using GiaPha_Application.Service;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GiaPha_Application.Features.Auth.Command.Login;
public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginRespone>>
{
    private readonly IAuthRepository _authRepository;
    private readonly IJwtService _jwtService;
    public LoginCommandHandler(IAuthRepository authRepository , IJwtService jwtService)
    {
        _authRepository = authRepository;
        _jwtService = jwtService;
    }
    // public async Task<Result<LoginRespone>> Handle(LoginCommand request, CancellationToken cancellationToken)
    // {
    //     var user = await _authRepository.GetEmailByUsernameAsync(request.TenDangNhap);
    //     if (!user.IsSuccess)
    //     {
    //         throw new UnauthorizedAccessException("Email không tồn tại");
    //     }
    //     if (user.Data == null || !user.Data.Enabled)
    //     {
    //         throw new UnauthorizedAccessException("Tài khoản chưa được kích hoạt");
    //     }
    //     // Đổi mật khẩu sang hash và so sánh
    //     var isPasswordValid = BCrypt.Net.BCrypt.Verify(request.MatKhau, user.Data.MatKhauMaHoa);
    //     if (!isPasswordValid)
    //     {
    //         throw new UnauthorizedAccessException("Tên đăng nhập hoặc mật khẩu không đúng");
    //     }

    //     // Tạo JWT token
    //     var token = _jwtService.GenerateToken(user.Data);
    //     var tokenExpiration = _jwtService.GetTokenExpiration();

    //     // Tạo refresh token
    //     var refreshToken = _jwtService.GenerateRefreshToken();
    //     var refreshTokenExpiry = _jwtService.GetRefreshTokenExpiration();

    //     // Lưu refresh token vào database
    //     user.Data.SetRefreshToken(refreshToken, refreshTokenExpiry);
    //     await _authRepository.UpdateUserAsync(user.Data);
    //     await _authRepository.SaveChangesAsync();
    //     var response = new LoginRespone
    //     {
    //         Id = user.Data.Id,
    //         TenDangNhap = user.Data.TenDangNhap,
    //         Email = user.Data.Email,
    //         Token = token,
    //         GioiTinh = user.Data.GioiTinh,
    //         Role = user.Data.Role,
    //         MatKhauMaHoa = user.Data.MatKhauMaHoa,
    //         RefreshTokenExpiry= refreshTokenExpiry
    //     };
    //     return Result<LoginRespone>.Success(response);
    // }
    public async Task<Result<LoginRespone>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        // 1. Tìm user theo username
        var userResult = await _authRepository.GetEmailByUsernameAsync(request.TenDangNhap);
        if (userResult.Data == null)
        {
            return Result<LoginRespone>.Failure(ErrorType.NotFound,"ACCOUNT_NOT_FOUND"); // Mã lỗi cụ thể
        }

        var user = userResult.Data;

        // 2. Kiểm tra tài khoản có được kích hoạt chưa TRƯỚC KHI kiểm tra password
        if (!user.Enabled)
        {
            return Result<LoginRespone>.Failure(ErrorType.NotActivated,"ACCOUNT_NOT_ACTIVATED"); // Mã lỗi cụ thể
        }

        // 3. Kiểm tra password SAU khi đã biết tài khoản đã kích hoạt
        var isValidPassword = BCrypt.Net.BCrypt.Verify(request.MatKhau, user.MatKhauMaHoa);
        if (!isValidPassword)
        {
            return Result<LoginRespone>.Failure(ErrorType.WrongPassword,"WRONG_PASSWORD"); // Mã lỗi cụ thể
        }

        // 4. Tạo JWT token
        var token = _jwtService.GenerateToken(user);

        var response = new LoginRespone
        {
            Token = token,
            Email = user.Email,
            TenDangNhap = user.TenDangNhap,
            Role = user.Role
        };
        return Result<LoginRespone>.Success(response);
    }
}