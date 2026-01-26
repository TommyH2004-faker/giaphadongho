namespace GiaPha_Domain.Entities;
public class ThanhVien
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string HoTen { get; private set; } = null!;
    public string GioiTinh { get; private set; } = null!;
    public DateTime? NgaySinh { get; private set; }
    public string? NoiSinh { get; private set; }

    public DateTime? NgayMat { get; private set; }
    public string? NoiMat { get; private set; }

    public int DoiThu { get; private set; }
    public string? TieuSu { get; private set; }
    public string? AnhDaiDien { get; private set; }

    public Guid? ChiHoId { get; private set; }
    public ChiHo? ChiHo { get; private set; }
    private ThanhVien() { }
}
