using GiaPha_Domain.Enums;

namespace GiaPha_Domain.Entities;
public class TaiKhoanNguoiDung
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string TenDangNhap { get; private set; } = null!;
    public string MatKhauMaHoa { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public GioiTinh GioiTinh { get; private set; }
    public string Role { get; private set; } = null!;
    // QuanTri, BienTap, Xem
    private TaiKhoanNguoiDung() { }
}
