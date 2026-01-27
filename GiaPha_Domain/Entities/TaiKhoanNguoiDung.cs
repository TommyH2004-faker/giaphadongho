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
    public string? ActivationCode { get; private set; }
    public bool Enabled { get; private set; } 
    public DateTime? RefreshTokenExpiry { get; private set; }
    public string? RefreshToken { get; private set; }
    private TaiKhoanNguoiDung() { }

     public static TaiKhoanNguoiDung Register(
        string TenDangNhap,
        string email,
        string MatKhauMaHoa,
        string role = "User")
        {
            if (string.IsNullOrWhiteSpace(TenDangNhap))
                throw new ArgumentException("TenDangNhap is required");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required");

            if (string.IsNullOrWhiteSpace(MatKhauMaHoa))
                throw new ArgumentException("MatKhauMaHoa is required");

            // Tạo activation code 6 số
            var activationCode = new Random().Next(100000, 999999).ToString();

            var user = new TaiKhoanNguoiDung
            {
                TenDangNhap = TenDangNhap,
                Email = email,
                MatKhauMaHoa = MatKhauMaHoa,
                Role = role,
                ActivationCode = activationCode,
                Enabled = false
            };
            return user;
        }

      
        public void ChangePassword(string newPasswordHash)
        {
            if (string.IsNullOrWhiteSpace(newPasswordHash))
                throw new ArgumentException("PasswordHash required");

            MatKhauMaHoa = newPasswordHash;
        }

  

        public void Activate()
        {
            if (Enabled)
                throw new InvalidOperationException("User is already activated");
            
            Enabled = true;
            ActivationCode = null;
        
        }

        public void ChangeRole(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException("Role required");

            Role = role;
        }

        public void SetRefreshToken(string refreshToken, DateTime refreshTokenExpiry)
        {
    
            this.RefreshToken = refreshToken;
            this.RefreshTokenExpiry = refreshTokenExpiry;
        }
}
