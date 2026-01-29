using GiaPha_Application.Events.ThanhVienEvents;
using GiaPha_Application.Repository;
using GiaPha_Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GiaPha_Application.Features.ThanhVien.Command.EventHandler.Create;

public class CreateThanhVienNotification : INotificationHandler<CreateThanhVienEvent>
{
    private readonly ILogger<CreateThanhVienNotification> _logger;
    private readonly INotificationRepository _notificationRepository;
    public CreateThanhVienNotification(ILogger<CreateThanhVienNotification> logger, INotificationRepository notificationRepository)
    {
        _logger = logger;
        _notificationRepository = notificationRepository;
    }
    
    public async Task Handle(CreateThanhVienEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("📝 [THANHVIEN] Tạo notification cho thành viên mới ID {Id}", notification.Id);

        // Assuming these properties exist on the notification event, otherwise replace with correct source
        var tenChiHo = notification.HoTen;
        var chiHoId = notification.Idho;
        var noiDung = $"Thành viên mới đã được tạo: {notification.HoTen} vào lúc {notification.CreatedAt}.";
        var newNotification = new Notification(
            $"Thông báo cho chi họ {tenChiHo}: {noiDung}",
            isGlobal: false,
            chiHoId: chiHoId    
        );
        await _notificationRepository.AddAsync(newNotification);
    }
}