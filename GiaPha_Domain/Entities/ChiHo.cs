namespace GiaPha_Domain.Entities;

public class ChiHo
{
    public Guid Id { get; private set; }
    public string TenChiHo { get; private set; } = null!;
    public string? MoTa { get; private set; }

    public Guid HoId { get; set; }
    public Ho Ho { get; set; } = null!;

    public Guid? TruongChiId { get; set; }
    public ThanhVien? TruongChi { get; set; }

    public ICollection<ThanhVien> ThanhViens { get; set; } = new List<ThanhVien>();

    private ChiHo() { }

    public static ChiHo Create(string tenChiHo, Guid hoId, string? moTa)
    {
        return new ChiHo
        {
            Id = Guid.NewGuid(),
            TenChiHo = tenChiHo,
            HoId = hoId,
            MoTa = moTa
        };
    }

    public void AssignTruongChi(ThanhVien tv)
    {
        TruongChi = tv;
        TruongChiId = tv.Id;
    }

    public void Update(string tenChiHo,Guid hoId,string? moTa = null)
        {
            if(string.IsNullOrWhiteSpace(tenChiHo))
            {
                throw new ArgumentException("Tên chi họ không được để trống", nameof(tenChiHo));
            }
            if(hoId == Guid.Empty)
            {
                throw new ArgumentException("IdHọ không được để trống", nameof(hoId));
            }
            TenChiHo = tenChiHo;
            MoTa = moTa;
            HoId = hoId;
        }
    
}
