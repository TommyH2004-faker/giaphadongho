using GiaPha_Application.Repository;
using GiaPha_Domain.Entities;
using GiaPha_Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace GiaPha_Infrastructure.Repository;
public class ChiHoRepository : IChiHoRepository
{
    private readonly DbGiaPha _context;
    public ChiHoRepository(DbGiaPha context)
    {
        _context = context;
    }

    public async Task<ChiHo?> CreateChiHoAsync(ChiHo chiHo)
    {
        _context.ChiHos.Add(chiHo);
        await _context.SaveChangesAsync();
        return chiHo;
    }

    public async Task<bool> DeleteChiHoAsync(Guid id)
    {
        var chiHo = await _context.ChiHos.FindAsync(id);
        if (chiHo == null)
        {
            return false;
        }
        _context.ChiHos.Remove(chiHo);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<ChiHo>> GetAllChiHoAsync()
    {
        return await _context.ChiHos.ToListAsync();
    }

    public async Task<ChiHo?> GetChiHoByIdAsync(Guid chiHoId)
    {
        return await _context.ChiHos.FindAsync(chiHoId);
    }

    public async Task<ChiHo?> GetChiHoByNameAsync(string tenChiHo)
    {
        return await _context.ChiHos.FirstOrDefaultAsync(c => c.TenChiHo == tenChiHo);
    }

    public async Task<ChiHo> UpdateChiHoAsync(ChiHo chiHo)
    {
        _context.ChiHos.Update(chiHo);
        await _context.SaveChangesAsync();
        return chiHo;
    }
}