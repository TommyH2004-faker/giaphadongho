
using GiaPha_Domain.Entities;

namespace GiaPha_Application.Service
{
    public interface IJwtService
    {
        string GenerateToken(TaiKhoanNguoiDung user);
        string GenerateRefreshToken();
        int? ValidateToken(string token);
        DateTime GetTokenExpiration();
        DateTime GetRefreshTokenExpiration();
    }
}
