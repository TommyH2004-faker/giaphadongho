namespace GiaPha_Domain.Entities;
public class ChiHo
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string TenChiHo { get; private set; } = null!;
    public string? MoTa { get; private set; }
    public Guid IdHo { get; private set; }
    public Guid? TruongChiId { get; private set; }  
    public Ho Ho { get; private set; } = null!;
    public ThanhVien TruongChi { get; private set; } = null!;

    public ICollection<ThanhVien> ThanhViens { get; private set; } 
        = new List<ThanhVien>();
    private ChiHo() { }
    public static ChiHo Create(
        string tenChiHo,
        Guid? idHo,
        string? moTa = null)
    {
        if(string.IsNullOrWhiteSpace(tenChiHo))
        {
            throw new ArgumentException("Tên chi họ không được để trống", nameof(tenChiHo));
        }
        var chiHo = new ChiHo
        {   
            IdHo = idHo ?? Guid.Empty,
            TenChiHo = tenChiHo,
            MoTa = moTa,
        };
        return chiHo;
    }
    public void Update(
        string tenChiHo,
        string? moTa = null)
    {
        if (string.IsNullOrWhiteSpace(tenChiHo))
        {
            throw new ArgumentException("Tên chi họ không được để trống", nameof(tenChiHo));
        }
        TenChiHo = tenChiHo;
        MoTa = moTa;
    }
    public void AssignTruongChi(ThanhVien truongChi)
    {
        if (truongChi == null)
        {
            throw new ArgumentNullException(nameof(truongChi), "Trưởng chi không được null");
        }
        TruongChi = truongChi;
        TruongChiId = truongChi.Id;
    }
    
}
