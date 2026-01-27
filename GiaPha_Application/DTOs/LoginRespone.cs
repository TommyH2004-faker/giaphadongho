using GiaPha_Domain.Enums;

namespace GiaPha_Application.DTOs;
public class LoginRespone
{
    public Guid Id { get; set; }
    public string? TenDangNhap { get; set; }
    public string? Email { get; set; }
    public GioiTinh GioiTinh { get; set; }
    public string? Role { get; set; }
    public string? Token { get; set; }
    public DateTime? RefreshTokenExpiry { get; set; }
    public string MatKhauMaHoa { get; set; } = null!;
}