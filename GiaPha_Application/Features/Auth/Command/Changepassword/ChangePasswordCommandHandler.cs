using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using GiaPha_Application.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GiaPha_Application.Features.Auth.Command.Changepassword.ChangePasswordCommand;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand,Result<bool>>
{
    private readonly IAuthRepository _userRepository;

    public ChangePasswordCommandHandler(IAuthRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<bool>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        // Lấy user từ database
        var user = await _userRepository.GetUserByIdAsync(request.UserId);
        if (user == null)
        {
            throw new InvalidOperationException("User not found");
        }

        // Kiểm tra user đã kích hoạt chưa
        if (user.Data == null || user.Data.Enabled == false)
        {
            throw new InvalidOperationException("Account not activated");
        }

        // Xác thực mật khẩu cũ
        var isOldPasswordValid = BCrypt.Net.BCrypt.Verify(request.CurrentPassword, user.Data.MatKhauMaHoa);
        if (!isOldPasswordValid)
        {
            throw new InvalidOperationException("Old password is incorrect");
        }

        // Hash mật khẩu mới
        var newPasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);

        // Thay đổi mật khẩu (domain method)
        user.Data.ChangePassword(newPasswordHash);

        // ⭐ Raise domain event
        user.Data.RaisePasswordChangedEvent();

        // Lưu thay đổi và dispatch events
        await _userRepository.UpdateUserAsync(user.Data);
        await _userRepository.SaveChangesAsync(); // Dispatch events

        return Result<bool>.Success(true);
    }
}