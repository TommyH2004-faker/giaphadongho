using GiaPha_Domain.Common;

namespace GiaPha_Domain.Entities;

public class ThanhVien :IHasDomainEvents
{
    public Guid Id { get; private set; }
    public string HoTen { get; private set; } = null!;
    public bool GioiTinh { get; private set; }
    public DateTime? NgaySinh { get; private set; }
    public DateTime? NgayMat { get; private set; }
    public string? NoiSinh { get; private set; }
    public string? TieuSu { get; private set; }
    public int TrangThai { get; private set; }

    public Guid HoId { get; set; }
    public Ho Ho { get; set; } = null!;

    public Guid ChiHoId { get; set; }
    public ChiHo ChiHo { get; set; } = null!;

    public Guid DoiId { get; set; }
    public Doi Doi { get; set; } = null!;

    public IReadOnlyCollection<IDomainEvent> DomainEvents => DomainEventsInternal.AsReadOnly();
    private List<IDomainEvent> DomainEventsInternal { get; } = new List<IDomainEvent>();

    private ThanhVien() { }

    public static ThanhVien Create(
        string hoTen,
        string email,
        bool gioiTinh,
        DateTime? ngaySinh = null,
        string? noiSinh = null,
        DateTime? ngayMat = null,
        string? noiMat = null,
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
            Id = Guid.NewGuid(),
            HoTen = hoTen,
            GioiTinh = gioiTinh,
            NgaySinh = ngaySinh,
            NoiSinh = noiSinh,
            NgayMat = ngayMat,
            TieuSu = tieuSu,
            TrangThai = 1,
            ChiHoId = chiHoId ?? Guid.Empty
        };
        return thanhVien;
    }
 
    public void RaiseCreatedEvent()
    {
    
    }
    
    public void RaiseCreatedEventWithHoId(Guid? hoId)
    {
      
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
