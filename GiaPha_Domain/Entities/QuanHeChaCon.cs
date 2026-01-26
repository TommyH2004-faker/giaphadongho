namespace GiaPha_Domain.Entities;
public class QuanHeChaCon
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public Guid ChaMeId { get; private set; }
    public ThanhVien ChaMe { get; private set; } = null!;

    public Guid ConId { get; private set; }
    public ThanhVien Con { get; private set; } = null!;

    public string LoaiQuanHe { get; private set; } = null!; 
    // Cha, Me, Nuoi
    private QuanHeChaCon() { }
}
