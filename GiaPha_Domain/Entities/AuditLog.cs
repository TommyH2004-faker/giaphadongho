namespace GiaPha_Domain.Entities;

public class AuditLog
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string EntityName { get; private set; } = null!;
    public Guid EntityId { get; private set; }
    public string Action { get; private set; } = null!; // Create, Update, Delete
    public string? ChangedBy { get; private set; }
    public DateTime ChangedAt { get; private set; }
    public string? Changes { get; private set; } // JSON mô tả thay đổi
    private AuditLog() { }
}
