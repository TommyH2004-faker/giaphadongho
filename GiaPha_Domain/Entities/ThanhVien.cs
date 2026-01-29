using GiaPha_Domain.Common;
using GiaPha_Domain.Enums;
using static GiaPha_Domain.Events.ThanhVienEvent;

namespace GiaPha_Domain.Entities;
public class ThanhVien : IHasDomainEvents
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string HoTen { get; private set; } = null!;
    public GioiTinh GioiTinh { get; private set; }
    public DateTime? NgaySinh { get; private set; }
    public string? NoiSinh { get; private set; }

    public DateTime? NgayMat { get; private set; }
    public string? NoiMat { get; private set; }

    public int DoiThu { get; private set; }
    public string? TieuSu { get; private set; }
    public string? AnhDaiDien { get; private set; }
    public string Email { get; private set; } = null!;
    public Guid? ChiHoId { get; private set; }
    public ChiHo? ChiHo { get; private set; }
    public IReadOnlyCollection<IDomainEvent> DomainEvents => DomainEventsInternal.AsReadOnly();
    private List<IDomainEvent> DomainEventsInternal { get; } = new List<IDomainEvent>(); 
    private ThanhVien() { }
    public static ThanhVien Create(
        string hoTen,
        string email,
        GioiTinh gioiTinh,
        DateTime? ngaySinh = null,
        string? noiSinh = null,
        DateTime? ngayMat = null,
        string? noiMat = null,
        int doiThu = 0,
        string? tieuSu = null,
        string? anhDaiDien = null,
        Guid? chiHoId = null)
    {
        if (string.IsNullOrWhiteSpace(hoTen))
        {
            throw new ArgumentException("Họ tên không được để trống", nameof(hoTen));
        }
        var thanhVien = new ThanhVien
        {
            HoTen = hoTen,
            GioiTinh = gioiTinh,
            NgaySinh = ngaySinh,
            NoiSinh = noiSinh,
            NgayMat = ngayMat,
            NoiMat = noiMat,
            DoiThu = doiThu,
            TieuSu = tieuSu,
            AnhDaiDien = anhDaiDien,
            ChiHoId = chiHoId,
            Email = email
        };
        return thanhVien;
    }
    // Raise event create 
    public void RaiseCreatedEvent()
    {
        AddDomainEvent(new ThanhVienCreated(
            this.Id,
            this.HoTen,
            this.Email,
            this.ChiHo != null ? this.ChiHo.TenChiHo : string.Empty,
            DateTime.UtcNow,
            this.ChiHoId ?? Guid.Empty
        ));
    }

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        DomainEventsInternal.Add(domainEvent);
    }

    public void RemoveDomainEvent(IDomainEvent domainEvent)
    {
        DomainEventsInternal.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        DomainEventsInternal.Clear();
    }
}
