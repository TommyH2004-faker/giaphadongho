using GiaPha_Application.Common;
using GiaPha_Domain.Entities;

namespace GiaPha_Application.Repository;
public interface IThanhVienRepository
{
    Task<Result<ThanhVien?>> CreateThanhVienAsync(ThanhVien thanhVien);
    Task<Result<bool>> DeleteThanhVienAsync(Guid id);
    Task<Result<IEnumerable<ThanhVien>>> GetAllThanhVienAsync();
    Task<Result<ThanhVien?>> GetThanhVienByIdAsync(Guid thanhVienId);
    Task<Result<ThanhVien?>> GetThanhVienByNameAsync(string hoTen);
    Task SaveChangesAsync();
    Task<Result<ThanhVien>> UpdateThanhVienAsync(ThanhVien thanhVien);
}