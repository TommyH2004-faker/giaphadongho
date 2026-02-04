namespace GiaPha_Domain.Entities;

public class SuKien
{
    public Guid Id { get; private set; }
    public Guid ThanhVienId { get; set; }
    public ThanhVien ThanhVien { get; set; } = null!;

    public string LoaiSuKien { get; private set; } = null!;
    public DateTime NgayXayRa { get; private set; }
    public string? DiaDiem { get; private set; }
    public string? MoTa { get; private set; }

    private SuKien() { }
}
