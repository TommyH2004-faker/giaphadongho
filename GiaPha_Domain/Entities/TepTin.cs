namespace GiaPha_Domain.Entities;
public class TepTin
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string DuongDan { get; private set; } = null!;
    public string LoaiTep { get; private set; } = null!;

    public Guid? ThanhVienId { get; private set; }
    public Guid? SuKienId { get; private set; }

    public string? MoTa { get; private set; }
    private TepTin() { }
}
