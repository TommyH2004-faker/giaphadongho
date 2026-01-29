using GiaPha_Application.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using TodoApp.Application.Service;


namespace GiaPha_Application.Features.Auth.Command.EventHandlers.ChangePassword
{
    /// <summary>
    /// Event Handler: Gửi email cảnh báo khi user đổi mật khẩu
    /// </summary>
    public class UserPasswordChangedNotificationHandler : INotificationHandler<UserPasswordChangedEvent>
    {
        private readonly ILogger<UserPasswordChangedNotificationHandler> _logger;
        private readonly IEmailService _emailService;

        public UserPasswordChangedNotificationHandler(
            ILogger<UserPasswordChangedNotificationHandler> logger,
            IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public async Task Handle(UserPasswordChangedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("📧 [USER] Gửi email cảnh báo đổi mật khẩu cho user ID {IdUser}", notification.id);

            var subject = "🔒 Mật khẩu đã được thay đổi";
            var body = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset=""UTF-8"">
                    <style>
                        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; background-color: #f4f6f8; }}
                        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
                        .header {{ background: #7b1fa2; color: white; padding: 30px; text-align: center; border-radius: 10px 10px 0 0; }}
                        .content {{ background: #ffffff; padding: 30px; border-radius: 0 0 10px 10px; }}
                        .alert {{ margin-top: 20px; padding: 15px; background: #fff3cd; border-left: 5px solid #ff9800; border-radius: 5px; }}
                        .footer {{ margin-top: 25px; font-size: 13px; color: #777; text-align: center; }}
                    </style>
                </head>
                <body>
                    <div class=""container"">
                        <div class=""header"">
                            <h1> Thông báo bảo mật</h1>
                            <p>Hệ thống Gia Phả Dòng Họ</p>
                        </div>

                        <div class=""content"">
                            <p>Kính gửi thành viên,</p>

                            <p>Mật khẩu của tài khoản trên hệ thống <strong>Gia Phả Dòng Họ</strong> của bạn vừa được thay đổi vào thời điểm:</p>

                            <p style=""font-size:18px; text-align:center;"">
                                <strong>{notification.ChangedAt:dd/MM/yyyy HH:mm:ss} UTC</strong>
                            </p>

                            <div class=""alert"">
                                 <strong>Nếu bạn không thực hiện thao tác này</strong>, vui lòng liên hệ ngay với Ban Quản Trị để được hỗ trợ bảo vệ tài khoản.
                            </div>

                            <p style=""margin-top:20px;"">
                                Xin cảm ơn bạn đã sử dụng hệ thống quản lý Gia Phả Dòng Họ.
                            </p>
                        </div>

                        <div class=""footer"">
                            <p>© {DateTime.UtcNow.Year} Hệ thống Gia Phả Dòng Họ</p>
                            <p>Email này được gửi tự động, vui lòng không trả lời.</p>
                        </div>
                    </div>
                </body>
                </html>";


            await _emailService.SendEmailAsync(notification.Email, subject, body, isHtml: true);
            _logger.LogInformation("[USER] Đã gửi email cảnh báo bảo mật cho {Email}", notification.Email);
        }
    }
}
