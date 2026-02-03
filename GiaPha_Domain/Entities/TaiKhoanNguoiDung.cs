using GiaPha_Domain.Common;
using GiaPha_Domain.Enums;
using static GiaPha_Domain.Events.UserEvents;

namespace GiaPha_Domain.Entities;
public class TaiKhoanNguoiDung :IHasDomainEvents
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string TenDangNhap { get; private set; } = null!;
    public string MatKhauMaHoa { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string? Avatar { get; private set; }
    public GioiTinh GioiTinh { get; private set; }
    public string Role { get; private set; } = null!;
    // QuanTri, BienTap, Xem
    public string? ActivationCode { get; private set; }
    public bool Enabled { get; private set; } 
    public DateTime? RefreshTokenExpiry { get; private set; }
    public string? RefreshToken { get; private set; }
    
    // Relationship với ThanhVien
    public Guid? ThanhVienId { get; private set; }
    public ThanhVien? ThanhVien { get; private set; }
    // phone number
    public string? SoDienThoai { get; private set; }
    
    // Relationship với ChiHo (dùng cho phân quyền thông báo)
    public Guid? ChiHoId { get; private set; }
    public ChiHo? ChiHo { get; private set; }

    public IReadOnlyCollection<IDomainEvent> DomainEvents => DomainEventsInternal.AsReadOnly();
    private List<IDomainEvent> DomainEventsInternal { get; } = new List<IDomainEvent>();

    private TaiKhoanNguoiDung() { }

     public static TaiKhoanNguoiDung Register(
        string TenDangNhap,
        string email,
        string MatKhauMaHoa,
        string? SoDienThoai,
        GioiTinh gioiTinh,
        string role)
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
                GioiTinh = gioiTinh,
                Role = role,
                ActivationCode = activationCode,
                Enabled = false,
                SoDienThoai = SoDienThoai
            };
            return user;
        }
         public void RaiseRegisteredEvent()
        {
            AddDomainEvent(new UserRegistered(
                this.Id,
                this.Email,
                this.TenDangNhap,
                this.ActivationCode!
            ));
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
            AddDomainEvent(new UserActivated(
                this.Id,
                this.Email,
                DateTime.UtcNow
            ));
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

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            DomainEventsInternal.Add(domainEvent);
        }

        public void RemoveDomainEvent(IDomainEvent domainEvent)
        {
            DomainEventsInternal.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            DomainEventsInternal.Clear();
        }

        public void RaisePasswordChangedEvent()
        {
            AddDomainEvent(new UserPasswordChanged(
                this.Id,
                this.Email,
                DateTime.UtcNow
            ));
        }
        public void ForgotPassword(string newPasswordHash)
        {
            if (string.IsNullOrWhiteSpace(newPasswordHash))
                throw new ArgumentException("New password hash required");

            MatKhauMaHoa = newPasswordHash;
        }
        
        // Link với ThanhVien
        public void LinkToThanhVien(Guid thanhVienId)
        {
            ThanhVienId = thanhVienId;
        }
        
        // Set ChiHo cho user
        public void SetChiHo(Guid chiHoId)
        {
            ChiHoId = chiHoId;
        }
        
        public void RaiseForgotPasswordEvent(string plainPassword)
        {
            AddDomainEvent(new UserForgotPassword(
                this.Id,
                this.Email,
                plainPassword,
                DateTime.UtcNow
            ));
        }
}
