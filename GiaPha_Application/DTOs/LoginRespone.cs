

namespace GiaPha_Application.DTOs;
public class LoginRespone
{
    public string? TenDangNhap { get; set; }
    public string? Email { get; set; }
    public string? Role { get; set; }
    public string? Token { get; set; }
    
    // Danh sách các Ho mà user thuộc về
    public List<HoResponse> AvailableHos { get; set; } = new();
    
    // Ho hiện tại đang chọn (nếu có)
    public Guid? SelectedHoId { get; set; }
}