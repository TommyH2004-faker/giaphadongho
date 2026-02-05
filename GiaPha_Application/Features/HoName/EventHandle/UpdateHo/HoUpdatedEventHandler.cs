using GiaPha_Application.Events.HoEvents;
using GiaPha_Application.Repository;
using GiaPha_Domain.Entities;
using MediatR;

namespace GiaPha_Application.Features.HoName.EventHandle.UpdateHo;

public class HoUpdatedEventHandler : INotificationHandler<HoUpdatedEventWrapper>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IThanhVienRepository _thanhVienRepository;
    private readonly IHoRepository _hoRepository;

    public HoUpdatedEventHandler(
        INotificationRepository notificationRepository,
        IThanhVienRepository thanhVienRepository,
        IHoRepository hoRepository)
    {
        _notificationRepository = notificationRepository;
        _thanhVienRepository = thanhVienRepository;
        _hoRepository = hoRepository;
    }

    public async Task Handle(HoUpdatedEventWrapper notification, CancellationToken cancellationToken)
    {
        var evt = notification.DomainEvent;

        // Chỉ xử lý khi có ThuyToId (tức là đã thay đổi thủy tổ)
        if (!evt.ThuyToId.HasValue)
            return;

        // Lấy thông tin thành viên thủy tổ
        var thanhVienResult = await _thanhVienRepository.GetThanhVienByIdAsync(evt.ThuyToId.Value);
        if (!thanhVienResult.IsSuccess || thanhVienResult.Data == null)
            return;

        var thanhVien = thanhVienResult.Data;

        // Tạo nội dung thông báo
        var noiDung = $"Họ '{evt.TenHo}' đã thay đổi thủy tổ thành: {thanhVien.HoTen}";

        // Tạo notification cho toàn bộ họ
        var notif = Notification.Create(
            noiDung: noiDung,
            isGlobal: false,
            nguoiNhanId: null, // Gửi cho cả họ, không gửi cho người cụ thể
            chiHoId: null,
            hoId: evt.HoId
        );

        await _notificationRepository.AddAsync(notif);
    }
}
