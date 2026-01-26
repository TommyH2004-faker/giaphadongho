namespace GiaPha_Domain.Entities;
public class ThanhTuu
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public Guid ThanhVienId { get; private set; }
    public ThanhVien ThanhVien { get; private set; } = null!;

    public string TenThanhTuu { get; private set; } = null!;
    public int? NamDatDuoc { get; private set; }
    public string? MoTa { get; private set; }
    private ThanhTuu() { }
}
