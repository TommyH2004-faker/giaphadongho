namespace GiaPha_Domain.Entities;

public class Comment
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string NoiDung { get; private set; } = null!;
    public Guid? ThanhVienId { get; private set; }
    public Guid? SuKienId { get; private set; }
    public Guid? CreatedById { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    private Comment() { }
}
