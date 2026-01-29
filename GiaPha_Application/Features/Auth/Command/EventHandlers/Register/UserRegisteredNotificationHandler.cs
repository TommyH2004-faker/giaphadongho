using GiaPha_Application.Events;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TodoApp.Application.Service;


namespace GiaPha_Application.Features.Auth.Command.EventHandlers.Register
{
    /// <summary>
    /// Event Handler: Gửi email xác thực khi user đăng ký
    /// </summary>
    public class UserRegisteredNotificationHandler : INotificationHandler<UserRegisteredEvent>
    {
        private readonly ILogger<UserRegisteredNotificationHandler> _logger;
        private readonly IEmailService _emailService;

        private readonly string _frontendUrl;

        public UserRegisteredNotificationHandler(
            ILogger<UserRegisteredNotificationHandler> logger,
            IEmailService emailService,

            IConfiguration configuration)
        {
            _logger = logger;
            _emailService = emailService;
            _frontendUrl = configuration["FrontendUrl"] ?? "http://localhost:3000";
        }

        public async Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("📧 [USER] Gửi email xác thực cho user {Email}", notification.Email);

            var activationLink = $"{_frontendUrl}/activate?code={notification.ActivationCode}&userId={notification.id}";

            // 2. Gửi email xác thực cho user
            var subject = "Chào mừng đến Gia Phả Dòng Họ - Kích hoạt tài khoản";
            var body = $@"
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset=""UTF-8"">
                <style>
                    body {{
                        font-family: Arial, sans-serif;
                        background-color: #f5f7fb;
                        color: #333;
                    }}
                    .container {{
                        max-width: 600px;
                        margin: auto;
                        background: #ffffff;
                        border-radius: 10px;
                        overflow: hidden;
                        box-shadow: 0 4px 10px rgba(0,0,0,0.05);
                    }}
                    .header {{
                        background: linear-gradient(135deg, #0f766e, #115e59);
                        color: #ffffff;
                        padding: 30px;
                        text-align: center;
                    }}
                    .header h1 {{
                        margin: 0;
                        font-size: 24px;
                    }}
                    .content {{
                        padding: 30px;
                    }}
                    .code-box {{
                        background: #f0fdfa;
                        border: 2px dashed #0f766e;
                        padding: 20px;
                        text-align: center;
                        border-radius: 8px;
                        margin: 20px 0;
                    }}
                    .code {{
                        font-size: 30px;
                        letter-spacing: 6px;
                        font-weight: bold;
                        color: #0f766e;
                    }}
                    .button {{
                        display: inline-block;
                        padding: 14px 36px;
                        background: #0f766e;
                        color: #ffffff !important;
                        text-decoration: none;
                        border-radius: 30px;
                        font-weight: bold;
                    }}
                    .footer {{
                        background: #f9fafb;
                        text-align: center;
                        padding: 15px;
                        font-size: 12px;
                        color: #777;
                    }}
                </style>
            </head>

            <body>
                <div class=""container"">
                    <div class=""header"">
                        <h1>HỆ THỐNG GIA PHẢ DÒNG HỌ</h1>
                        <p>Kết nối nguồn cội – Gìn giữ truyền thống</p>
                    </div>

                    <div class=""content"">
                        <h2>Xin chào {notification.TenDangNhap},</h2>

                        <p>
                            Bạn vừa đăng ký tài khoản trên <strong>Hệ thống Gia Phả Dòng Họ</strong>.
                        </p>

                        <p>
                            Để hoàn tất việc đăng ký, vui lòng xác thực tài khoản bằng một trong hai cách dưới đây:
                        </p>

                        <h3> Mã xác thực</h3>
                        <div class=""code-box"">
                            <div class=""code"">{notification.ActivationCode}</div>
                        </div>

                        <h3> Hoặc nhấn vào liên kết</h3>
                        <p style=""text-align:center;"">
                            <a href=""{activationLink}"" class=""button"">
                                Xác thực tài khoản
                            </a>
                        </p>

                        <p style=""margin-top:25px;color:#555;"">
                            Mã xác thực có hiệu lực trong vòng <strong>24 giờ</strong>.<br/>
                            Nếu bạn không thực hiện đăng ký, vui lòng bỏ qua email này.
                        </p>
                    </div>

                    <div class=""footer"">
                        <p>© 2026 Hệ thống Gia Phả Dòng Họ</p>
                        <p>Email được gửi tự động, vui lòng không phản hồi.</p>
                    </div>
                </div>
            </body>
            </html>";


            await _emailService.SendEmailAsync(notification.Email, subject, body, isHtml: true);
            _logger.LogInformation(" [USER] Đã gửi email xác thực thành công cho {Email}", notification.Email);
        }
    }
}
