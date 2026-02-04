namespace GiaPha_Domain.Entities;

public class Ho
{
    // ====== Keys ======
    public Guid Id { get; private set; }

    // ====== Properties ======
    public string TenHo { get; private set; } = null!;
    public string? MoTa { get; private set; }
    public string? HinhAnh { get; private set; }
    public DateTime NgayTao { get; private set; }
    public string? QueQuan { get; private set; }

    // ====== FK Thủy Tổ ======
    public Guid? ThuyToId { get; set; }
    public ThanhVien? ThuyTo { get; set; }

    // ====== Navigation ======
    public ICollection<ChiHo> ChiHos { get; set; } = new List<ChiHo>();
    public ICollection<Doi> Dois { get; set; } = new List<Doi>();

    // ====== Constructor ======
    private Ho() { }

    // ====== Factory ======
    public static Ho Create(string tenHo, string? moTa, string? queQuan)
    {
        if (string.IsNullOrWhiteSpace(tenHo))
            throw new ArgumentException("TenHo cannot be empty");

        return new Ho
        {
            Id = Guid.NewGuid(),
            TenHo = tenHo,
            MoTa = moTa,
            QueQuan = queQuan,
            NgayTao = DateTime.UtcNow
        };
    }


    public void SetThuyTo(Guid thanhVienId)
    {
        ThuyToId = thanhVienId;
    }

    public void Update(string tenHo, string? moTa)
    {
        if (string.IsNullOrWhiteSpace(tenHo))
            throw new ArgumentException("TenHo cannot be empty");

        TenHo = tenHo;
        MoTa = moTa;
    }
}
