namespace GiaPha_Domain.Entities;

public class Ho
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string TenHo { get; private set; } = null!;
    public string? MoTa { get; private set; }
    public ICollection<ChiHo> CacChiHo { get; private set; } = new List<ChiHo>();
    private Ho() { }
}
