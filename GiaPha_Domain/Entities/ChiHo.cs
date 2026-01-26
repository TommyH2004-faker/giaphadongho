namespace GiaPha_Domain.Entities;
public class ChiHo
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string TenChiHo { get; private set; } = null!;
    public string? MoTa { get; private set; }

    public Guid? TruongChiId { get; private set; }  
    public ThanhVien TruongChi { get; private set; } = null!;

    public ICollection<ThanhVien> ThanhViens { get; private set; } 
        = new List<ThanhVien>();
    private ChiHo() { }
    
}
