using GiaPha_Domain.Entities;

namespace GiaPha_Application.Repository;
public interface IChiHoRepository
{
    Task<ChiHo?> CreateChiHoAsync(ChiHo chiHo);
    Task<bool> DeleteChiHoAsync(Guid id);
    Task<IEnumerable<ChiHo>> GetAllChiHoAsync();
    Task<ChiHo?> GetChiHoByIdAsync(Guid chiHoId);
    Task<ChiHo?> GetChiHoByNameAsync(string tenChiHo);
    Task<ChiHo> UpdateChiHoAsync(ChiHo chiHo);
}