using GiaPha_Application.Common;
using GiaPha_Application.Repository;
using MediatR;

namespace GiaPha_Application.Features.Auth.Command.ForgetPassword;

public class ForgetPasswordHandle : IRequestHandler<ForgetPasswordCommand, Result<bool>>
{
    private readonly IAuthRepository _authRepository;
    public ForgetPasswordHandle(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }
    public async Task<Result<bool>> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
    {   
        var userResult = await _authRepository.GetUserByEmailAsync(request.Email);
    if (userResult == null || userResult.Data == null)
    {
        return Result<bool>.Failure(ErrorType.NotFound, "Người dùng không tồn tại.");
    }

    // 1. Sinh mật khẩu mới
    var plainPassword = GenerateRandomPassword(8);

    // 2. Băm mật khẩu
    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);

    // 3. Lưu mật khẩu mới
    userResult.Data.ChangePassword(hashedPassword);

    // 4. Raise event để gửi email
    userResult.Data.RaiseForgotPasswordEvent(plainPassword);

    await _authRepository.UpdateUserAsync(userResult.Data);
    await _authRepository.SaveChangesAsync();

    return Result<bool>.Success(true);
    }
    private string GenerateRandomPassword(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}