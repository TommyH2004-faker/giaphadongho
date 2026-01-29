using GiaPha_Application.Common;
using GiaPha_Domain.Entities;

namespace GiaPha_Application.Repository;
public interface IChiHoRepository
{
    Task<Result<ChiHo?>> CreateChiHoAsync(ChiHo chiHo);
    Task<Result<bool>> DeleteChiHoAsync(Guid id);
    Task<Result<IEnumerable<ChiHo>>> GetAllChiHoAsync();
    Task<Result<ChiHo?>> GetChiHoByIdAsync(Guid chiHoId);
    Task<Result<ChiHo?>> GetChiHoByNameAsync(string tenChiHo);
    Task<Result<ThanhVien>> GetThanhVienByIdAsync(Guid truongChiId);
    Task SaveChangesAsync();
    Task<Result<ChiHo>> Update(ChiHo chiHo);
    Task<Result<ChiHo>> UpdateChiHoAsync(ChiHo chiHo);
}