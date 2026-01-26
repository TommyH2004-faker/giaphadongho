namespace GiaPha_Domain.Entities;
public class HonNhan
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public Guid ChongId { get; private set; }
    public ThanhVien Chong { get; private set; } = null!;

    public Guid VoId { get; private set; }
    public ThanhVien Vo { get; private set; } = null!;

    public DateTime? NgayKetHon { get; private set; }
    public string? NoiKetHon { get; private set; }
    public DateTime? NgayLyHon { get; private set; }
    private HonNhan() { }
}
