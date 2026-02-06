using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using GiaPha_Application.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GiaPha_Application.Features.GiaPha.Queries.GetMyGiaPhaTree;

public class GetMyGiaPhaTreeHandler : IRequestHandler<GetMyGiaPhaTreeQuery, Result<GiaPhaTreeResponse>>
{
    private readonly IAuthRepository _authRepository;
    private readonly IGiaPhaRepository _giaPhaRepository;
    private readonly ILogger<GetMyGiaPhaTreeHandler> _logger;

    public GetMyGiaPhaTreeHandler(
        IAuthRepository authRepository, 
        IGiaPhaRepository giaPhaRepository,
        ILogger<GetMyGiaPhaTreeHandler> logger)
    {
        _authRepository = authRepository;
        _giaPhaRepository = giaPhaRepository;
        _logger = logger;
    }

    public async Task<Result<GiaPhaTreeResponse>> Handle(GetMyGiaPhaTreeQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("🔍 [GetMyGiaPhaTree] Lấy gia phả cho user: {UserId}", request.UserId);

        // Lấy thông tin user
        var userResult = await _authRepository.GetUserByIdAsync(request.UserId);
        
        if (!userResult.IsSuccess || userResult.Data == null)
        {
            _logger.LogWarning("⚠️ [GetMyGiaPhaTree] Không tìm thấy user: {UserId}", request.UserId);
            return Result<GiaPhaTreeResponse>.Failure(ErrorType.NotFound, "Không tìm thấy người dùng");
        }

        var user = userResult.Data;

        // Kiểm tra user đã có họ chưa
        if (!user.HoId.HasValue)
        {
            _logger.LogInformation("ℹ️ [GetMyGiaPhaTree] User {UserId} chưa có họ", request.UserId);
            return Result<GiaPhaTreeResponse>.Failure(
                ErrorType.NotFound, 
                "Bạn chưa thuộc họ nào. Vui lòng tạo họ mới hoặc liên hệ admin để được thêm vào họ.");
        }

        _logger.LogInformation("✅ [GetMyGiaPhaTree] User {UserId} thuộc họ: {HoId}", request.UserId, user.HoId.Value);

        // Lấy gia phả
        var treeResult = await _giaPhaRepository.BuildGiaPhaTreeAsync(
            user.HoId.Value, 
            request.MaxLevel, 
            request.IncludeNuGioi);

        if (!treeResult.IsSuccess)
        {
            _logger.LogError("❌ [GetMyGiaPhaTree] Lỗi khi build gia phả: {ErrorMessage}", treeResult.ErrorMessage);
            return Result<GiaPhaTreeResponse>.Failure(ErrorType.InternalServerError, treeResult.ErrorMessage!);
        }

        _logger.LogInformation("🎉 [GetMyGiaPhaTree] Lấy gia phả thành công cho họ: {HoId}", user.HoId.Value);
        
        return treeResult;
    }
}
