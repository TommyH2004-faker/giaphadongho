using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using GiaPha_Application.Repository;
using GiaPha_Application.Service;
using MediatR;

namespace GiaPha_Application.Features.Auth.Command.SwitchHo;

public class SwitchHoCommandHandler : IRequestHandler<SwitchHoCommand, Result<LoginRespone>>
{
    private readonly IAuthRepository _authRepository;
    private readonly IJwtService _jwtService;
    private readonly IThanhVienRepository _thanhVienRepository;

    public SwitchHoCommandHandler(
        IAuthRepository authRepository,
        IJwtService jwtService, 
        IThanhVienRepository thanhVienRepository)
    {
        _authRepository = authRepository;
        _jwtService = jwtService;
        _thanhVienRepository = thanhVienRepository;
    }

    public async Task<Result<LoginRespone>> Handle(SwitchHoCommand request, CancellationToken cancellationToken)
    {
        // 1. Lấy user
        var userResult = await _authRepository.GetUserByIdAsync(request.UserId);
        if (!userResult.IsSuccess || userResult.Data == null)
        {
            return Result<LoginRespone>.Failure(ErrorType.NotFound, "User không tìm thấy");
        }

        var user = userResult.Data;

        // 2. Kiểm tra user có thuộc Ho này không
        var thanhViensResult = await _thanhVienRepository.GetThanhVienByUserIdAsync(request.UserId);
        if (!thanhViensResult.IsSuccess || thanhViensResult.Data == null)
        {
            return Result<LoginRespone>.Failure(ErrorType.NotFound, "User không có ThanhVien");
        }

        // TODO: Kiểm tra user có thuộc Ho này qua ThanhVienHo
        // Tạm thời skip validation này

        // 3. Tạo token mới với HoId
        var token = _jwtService.GenerateToken(user, request.HoId);

        var response = new LoginRespone
        {
            Token = token,
            Email = user.Email,
            TenDangNhap = user.TenDangNhap,
            Role = user.Role,
            SelectedHoId = request.HoId,
            AvailableHos = new List<HoResponse>() // Có thể lấy lại nếu cần
        };

        return Result<LoginRespone>.Success(response);
    }
}