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
    private readonly IThanhVienRepository _thanhVienRepository;
    private readonly IHoRepository _hoRepository;

    public LoginCommandHandler(
        IAuthRepository authRepository, 
        IJwtService jwtService,
        IThanhVienRepository thanhVienRepository,
        IHoRepository hoRepository)
    {
        _authRepository = authRepository;
        _jwtService = jwtService;
        _thanhVienRepository = thanhVienRepository;
        _hoRepository = hoRepository;
    }
    public async Task<Result<LoginRespone>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        // user theo username
        var userResult = await _authRepository.GetEmailByUsernameAsync(request.TenDangNhap);
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

        // 4. Lấy danh sách Ho mà User thuộc về
        var userHos = await GetUserHosAsync(user.Id);
        
        // 5. Xử lý chọn Ho
        Guid? selectedHoId = null;
        if (userHos.Count == 1)
        {
            // Tự động chọn nếu chỉ có 1 Ho
            selectedHoId = userHos.First().HoId;
        }
        // Nếu có nhiều Ho, frontend sẽ gọi API riêng để chọn Ho

        // 6. Tạo JWT token với HoId (nếu có)
        var token = _jwtService.GenerateToken(user, selectedHoId);

        var response = new LoginRespone
        {
            Token = token,
            Email = user.Email,
            TenDangNhap = user.TenDangNhap,
            Role = user.Role,
            AvailableHos = userHos.Select(h => new HoResponse 
            {
                Id = h.HoId,
                TenHo = h.Ho?.TenHo
            }).ToList(),
            SelectedHoId = selectedHoId
        };
        return Result<LoginRespone>.Success(response);
    }

    private async Task<List<(Guid HoId, Ho? Ho)>> GetUserHosAsync(Guid userId)
    {
        try
        {
            // 1. Tìm ThanhVien của User
            var thanhViensResult = await _thanhVienRepository.GetThanhVienByUserIdAsync(userId);
            if (!thanhViensResult.IsSuccess || thanhViensResult.Data == null || !thanhViensResult.Data.Any())
            {
                return new List<(Guid, Ho?)>();
            }

            // 2. Lấy Ho từ từng ThanhVien qua ThanhVienHo
            var userHos = new List<(Guid HoId, Ho? Ho)>();
            
            foreach (var thanhVien in thanhViensResult.Data)
            {
                var hosResult = await _hoRepository.GetHosByThanhVienIdAsync(thanhVien.Id);
                if (hosResult.IsSuccess && hosResult.Data != null)
                {
                    foreach (var ho in hosResult.Data)
                    {
                        if (!userHos.Any(uh => uh.HoId == ho.Id)) // Tránh duplicate
                        {
                            userHos.Add((ho.Id, ho));
                        }
                    }
                }
            }

            return userHos;
        }
        catch
        {
            return new List<(Guid, Ho?)>();
        }
    }
}