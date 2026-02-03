using GiaPha_Application.Events;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TodoApp.Application.Service;


namespace GiaPha_Application.Features.Auth.Command.EventHandlers.Active
{
    /// <summary>
    /// Event Handler: Gửi email chúc mừng khi user kích hoạt tài khoản
    /// </summary>
    public class UserActivatedNotificationHandler : INotificationHandler<UserActivatedEvent>
    {
        private readonly ILogger<UserActivatedNotificationHandler> _logger;
        private readonly IEmailService _emailService;
      
        private readonly string _frontendUrl;

        public UserActivatedNotificationHandler(
            ILogger<UserActivatedNotificationHandler> logger,
            IEmailService emailService,
         
            IConfiguration configuration)
        {
            _logger = logger;
            _emailService = emailService;
            _frontendUrl = configuration["FrontendUrl"] ?? "http://localhost:3000";
        }

        public async Task Handle(UserActivatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("📧 [USER] Gửi email chúc mừng kích hoạt cho user ID {IdUser}", notification.id);

           var subject = "Kích hoạt tài khoản thành công - Hệ thống Gia Phả Dòng Họ";

          var body = $@"
            <!DOCTYPE html>
            <html>
            <head>
                <style>
                    body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
                    .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
                    .success {{ background: linear-gradient(135deg, #8E2DE2 0%, #4A00E0 100%); color: white; padding: 30px; text-align: center; border-radius: 10px; }}
                    .content {{ background: #f9f9f9; padding: 30px; margin-top: 20px; border-radius: 10px; }}
                    .button {{ display: inline-block; background: #4A00E0; color: white !important; padding: 15px 40px; text-decoration: none; border-radius: 25px; margin: 20px 0; font-weight: bold; }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <div class='success'>
                        <h1>🎉 Kích hoạt tài khoản thành công!</h1>
                        <p style='font-size: 18px; margin: 0;'>
                            Chào mừng bạn đến với Hệ thống Gia Phả Dòng Họ
                        </p>
                    </div>

                    <div class='content'>
                        <p>Tài khoản của bạn đã được kích hoạt thành công. Từ bây giờ bạn có thể:</p>

                        <ul>
                            <li>🌳 Xem và tra cứu cây phả hệ dòng họ</li>
                            <li>👨‍👩‍👧‍👦 Quản lý thông tin thành viên trong họ</li>
                            <li>✍️ Cập nhật tiểu sử, hình ảnh, sự kiện</li>
                            <li>🔔 Nhận thông báo từ dòng họ</li>
                        </ul>

                        <div style='text-align: center;'>
                            <a href='{_frontendUrl}/dangnhap' class='button'>
                                🔐 Đăng nhập hệ thống
                            </a>
                        </div>
                    </div>
                </div>
            </body>
            </html>";


            await _emailService.SendEmailAsync(notification.Email, subject, body, isHtml: true);
            _logger.LogInformation(" [USER] Đã gửi email chúc mừng kích hoạt cho {Email}", notification.Email);
        }
    }
}
