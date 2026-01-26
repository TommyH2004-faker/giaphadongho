namespace GiaPha_Domain.Entities;
public class Album
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string TenAlbum { get; private set; } = null!;
    public Guid? ThanhVienId { get; private set; }
    public Guid? SuKienId { get; private set; }
    public ICollection<TepTin> TepTins { get; private set; } = new List<TepTin>();
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    private Album() { }
}
