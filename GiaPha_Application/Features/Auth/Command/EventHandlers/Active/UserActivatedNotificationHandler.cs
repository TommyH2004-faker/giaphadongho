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

            var subject = " Tài khoản đã được kích hoạt thành công!";
            var body = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <style>
                        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
                        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
                        .success {{ background: linear-gradient(135deg, #11998e 0%, #38ef7d 100%); color: white; padding: 30px; text-align: center; border-radius: 10px; }}
                        .content {{ background: #f9f9f9; padding: 30px; margin-top: 20px; border-radius: 10px; }}
                        .button {{ display: inline-block; background: #11998e; color: white !important; padding: 15px 40px; text-decoration: none; border-radius: 25px; margin: 20px 0; font-weight: bold; }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='success'>
                            <h1>🎉 Chúc mừng!</h1>
                            <p style='font-size: 18px; margin: 0;'>Tài khoản của bạn đã được kích hoạt thành công!</p>
                        </div>
                        <div class='content'>
                            <p>Bây giờ bạn có thể:</p>
                            <ul>
                                <li>📚 Duyệt và mua sách yêu thích</li>
                                <li>⭐ Đánh giá và bình luận</li>
                                <li>❤️ Lưu sách vào danh sách yêu thích</li>
                                <li>🛒 Theo dõi đơn hàng của bạn</li>
                            </ul>
                            <div style='text-align: center;'>
                                <a href='{_frontendUrl}/login' class='button'>
                                    🚀 Đăng nhập ngay
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
