using GiaPha_Application.Events.UserEvents;
using MediatR;
using Microsoft.Extensions.Logging;
using TodoApp.Application.Service;

namespace GiaPha_Application.Features.Auth.Command.EventHandlers.Forgetpassword;

public class UserForgotPasswordEventHandler : INotificationHandler<UserForgotPasswordEvent>
{
    private readonly IEmailService _emailService;
    private readonly ILogger<UserForgotPasswordEventHandler> _logger;
    public UserForgotPasswordEventHandler(IEmailService emailService, ILogger<UserForgotPasswordEventHandler> logger)
    {
        _emailService = emailService;
        _logger = logger;
    }
    
    public async Task Handle(UserForgotPasswordEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("📧 [USER] Gửi email thông báo quên mật khẩu cho user ID {IdUser}", notification.id);

        var subject = " Mật khẩu đã được đặt lại";
        var body = $@"
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset=""UTF-8"">
                <style>
                    body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; background-color: #f4f6f8; }}
                    .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
                    .header {{ background: #1976d2; color: white; padding: 30px; text-align: center; border-radius: 10px 10px 0 0; }}
                    .content {{ background: #ffffff; padding: 30px; border-radius: 0 0 10px 10px; }}
                    .footer {{ margin-top: 25px; font-size: 13px; color: #777; text-align: center; }}
                </style>
            </head>
            <body>
                <div class=""container"">
                    <div class=""header"">
                        <h1>Thông báo đặt lại mật khẩu</h1>
                        <p>Hệ thống Gia Phả Dòng Họ</p>
                    </div>

                    <div class=""content"">
                        <p>Kính gửi thành viên,</p>

                        <p>Mật khẩu của tài khoản trên hệ thống <strong>Gia Phả Dòng Họ</strong> của bạn vừa được đặt lại vào thời điểm:</p>

                        <p style=""font-size:18px; text-align:center;"">
                            <strong>{notification.OccurredOn:dd/MM/yyyy HH:mm:ss} UTC</strong>
                        </p>

                        <p><b>Mật khẩu mới của bạn là:</b></p>
                        <p style=""font-size:20px; text-align:center; color:#1976d2;""><strong>{notification.plainPassword}</strong></p>

                        <p>Bạn hãy sử dụng mật khẩu này để đăng nhập lại hệ thống và nên đổi mật khẩu sau khi đăng nhập.</p>

                        <p>Nếu bạn không thực hiện yêu cầu này, vui lòng liên hệ với bộ phận hỗ trợ của chúng tôi ngay lập tức.</p>

                        <p>Trân trọng,<br/>Đội ngũ Gia Phả Dòng Họ</p>
                    </div>

                    <div class=""footer"">
                        <p>© 2024 Gia Phả Dòng Họ. All rights reserved.</p>
                    </div>
                </div>
            </body>
            </html>
        ";
        await _emailService.SendEmailAsync(notification.Email, subject, body);
    }
}