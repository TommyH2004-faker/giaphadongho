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
}