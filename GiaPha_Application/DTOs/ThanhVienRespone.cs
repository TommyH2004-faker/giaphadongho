

namespace GiaPha_Application.DTOs;
public class ThanhVienResponse
{
    public Guid Id { get; set; }
    public string HoTen { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool gioiTinh { get; set; }
    public DateTime NgaySinh { get; set; }
    public string NoiSinh { get; set; } = null!;
    public DateTime? ngayMat { get; set; }
    public string? noiMat { get; set; }
    public int DoiThu { get;set; }
    public string? TieuSu { get; set; }
    public string? AnhDaiDien { get;  set; }
    public Guid? ChiHoId { get; set; }
}