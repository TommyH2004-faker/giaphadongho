namespace GiaPha_WebAPI.Controller.LoginController;
public class LoginRequest
{
    public string TenDangNhap { get; set; } = null!;
    public string MatKhau { get; set; } = null!;
    public class ChangePasswordRequest
    {
        public Guid UserId { get; set; }
        public string CurrentPassword { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
    }
    public class ActivateUserRequest
    {
        public Guid UserId { get; set; }
        public string ActivationCode { get; set; } = null!;
    }
    public class ForgetPasswordRequest
    {
        public string Email { get; set; } = null!;
    }
    public class RegisterRequestDto
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public int Gender { get; set; } = 1; // 1=Nam, 2=Nữ, 3=Khác
}
}