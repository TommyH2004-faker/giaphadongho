namespace GiaPha_Domain.Entities;

public class Notification
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string NoiDung { get; private set; } = null!;
    public Guid? NguoiNhanId { get; private set; }
    public bool IsGlobal { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public bool DaDoc { get; private set; }
    public Guid? ChiHoId { get; private set; }
    public Guid? HoId { get; private set; } // Thông báo cho cả Họ
    
    public ChiHo? ChiHo { get; private set; }
    public Ho? Ho { get; private set; }

    public Notification(string noiDung, bool isGlobal = false, Guid? nguoiNhanId = null, Guid? chiHoId = null, Guid? hoId = null)
    {
        NoiDung = noiDung;
        IsGlobal = isGlobal;
        NguoiNhanId = nguoiNhanId;
        DaDoc = false;
        ChiHoId = chiHoId;
        HoId = hoId;
    }
    private Notification() { }
}