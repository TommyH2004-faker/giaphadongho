using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using GiaPha_Application.Repository;
using GiaPha_Application.Service;
using GiaPha_Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GiaPha_Application.Features.Auth.Command.Login;
public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginRespone>>
{
    private readonly IAuthRepository _authRepository;
    private readonly IJwtService _jwtService;
    private readonly IHoRepository _hoRepository;

    public LoginCommandHandler(
        IAuthRepository authRepository, 
        IJwtService jwtService,
        IHoRepository hoRepository)
    {
        _authRepository = authRepository;
        _jwtService = jwtService;
        _hoRepository = hoRepository;
    }
    public async Task<Result<LoginRespone>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        // user theo username
        var userResult = await _authRepository.GetUserByUsernameAsync(request.TenDangNhap);
        if (userResult.Data == null)
        {
            return Result<LoginRespone>.Failure(ErrorType.NotFound,"ACCOUNT_NOT_FOUND"); // Mã lỗi cụ thể
        }

        var user = userResult.Data;

        //Kiểm tra tài khoản có được kích hoạt chưa TRƯỚC KHI kiểm tra password
        if (!user.Enabled)
        {
            return Result<LoginRespone>.Failure(ErrorType.NotActivated,"ACCOUNT_NOT_ACTIVATED"); // Mã lỗi cụ thể
        }

        // 3. Kiểm tra password SAU khi đã biết tài khoản đã kích hoạt
        var isValidPassword = BCrypt.Net.BCrypt.Verify(request.MatKhau, user.MatKhau);
        if (!isValidPassword)
        {
            return Result<LoginRespone>.Failure(ErrorType.WrongPassword,"WRONG_PASSWORD"); // Mã lỗi cụ thể
        }

        // 4. Lấy thông tin Ho nếu user có HoId
        HoResponse? hoResponse = null;
        
        if (user.HoId.HasValue)
        {
            var hoResult = await _hoRepository.GetHoByIdAsync(user.HoId.Value);
            if (hoResult.IsSuccess && hoResult.Data != null)
            {
                hoResponse = new HoResponse
                {
                    Id = hoResult.Data.Id,
                    TenHo = hoResult.Data.TenHo,
                    MoTa = hoResult.Data.MoTa,
                    HinhAnh = hoResult.Data.HinhAnh,
                    QueQuan = hoResult.Data.QueQuan,
                    ThuyToId = hoResult.Data.ThuyToId
                };
            }
        }

        // 5. Tạo JWT token với HoId
        var token = _jwtService.GenerateToken(user, user.HoId);

        var response = new LoginRespone
        {
            Token = token,
            Email = user.Email,
            TenDangNhap = user.TenDangNhap,
            Role = user.Role,
            AvailableHos = hoResponse != null ? new List<HoResponse> { hoResponse } : new List<HoResponse>(),
            SelectedHoId = user.HoId
        };
        return Result<LoginRespone>.Success(response);
    }
}