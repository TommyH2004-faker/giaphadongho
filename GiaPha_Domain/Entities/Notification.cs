namespace GiaPha_Domain.Entities;

public class Notification
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string NoiDung { get; private set; } = null!;
    public Guid? NguoiNhanId { get; private set; }
    public bool IsGlobal { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public bool DaDoc { get; private set; }
    public Guid? ChiHoId { get; private set; } // <-- Thêm dòng này

    public Notification(string noiDung, bool isGlobal = false, Guid? nguoiNhanId = null, Guid? chiHoId = null)
    {
        NoiDung = noiDung;
        IsGlobal = isGlobal;
        NguoiNhanId = nguoiNhanId;
        DaDoc = false;
        ChiHoId = chiHoId;
    }
    private Notification() { }
}