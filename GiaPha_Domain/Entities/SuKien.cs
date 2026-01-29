using GiaPha_Domain.Enums;

namespace GiaPha_Domain.Entities;
public class SuKien
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public Guid ThanhVienId { get; private set; }
    public ThanhVien ThanhVien { get; private set; } = null!;

    public LoaiSuKien LoaiSuKien { get; private set; }
    // Sinh, Mat, Cuoi, ThanhTuu...

    public DateTime? NgayXayRa { get; private set; }
    public string? DiaDiem { get; private set; }
    public string? MoTa { get; private set; }
    private SuKien() { }
    
}
