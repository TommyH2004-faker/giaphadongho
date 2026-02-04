namespace GiaPha_Domain.Entities;

public class HonNhan
{
    public Guid Id { get; private set; }

    public Guid ChongId { get; set; }
    public ThanhVien Chong { get; set; } = null!;

    public Guid VoId { get; set; }
    public ThanhVien Vo { get; set; } = null!;

    public DateTime? NgayKetHon { get; private set; }
    public string? NoiKetHon { get; private set; }

    private HonNhan() { }

    public static HonNhan Create(Guid chongId, Guid voId)
    {
        return new HonNhan
        {
            Id = Guid.NewGuid(),
            ChongId = chongId,
            VoId = voId
        };
    }
}
