using GiaPha_Application.Common;
using GiaPha_Domain.Entities;

namespace GiaPha_Application.Repository
{
    public interface IAuthRepository
    {
         Task<Result<TaiKhoanNguoiDung>> CreateUserAsync(TaiKhoanNguoiDung user);
        Task<Result<TaiKhoanNguoiDung?>> GetUserByIdAsync(Guid id);
        Task<Result<TaiKhoanNguoiDung?>> GetEmailByUsernameAsync(string TenDangNhap);
        Task<Result<TaiKhoanNguoiDung?>> GetUserByEmailAsync(string email);
        
        Task<Result<IEnumerable<TaiKhoanNguoiDung>>> GetAllUsersAsync();
        Task<Result<TaiKhoanNguoiDung>> UpdateUserAsync(TaiKhoanNguoiDung user);
        Task<Result<bool>> DeleteUserAsync(int id);
        Task SaveChangesAsync();
        Task <Result<TaiKhoanNguoiDung>> AddUserAsync(TaiKhoanNguoiDung newUser);
   
    }
}