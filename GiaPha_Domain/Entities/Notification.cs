namespace GiaPha_Domain.Entities;

public class Notification
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string NoiDung { get; private set; } = null!;
    public Guid? NguoiNhanId { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public bool DaDoc { get; private set; }
    private Notification() { }
}
