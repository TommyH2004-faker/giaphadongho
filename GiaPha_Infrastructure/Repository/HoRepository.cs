using GiaPha_Application.Repository;
using GiaPha_Domain.Entities;
using GiaPha_Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace GiaPha_Infrastructure.Repository;

public class HoRepository : IHoRepository
{
    private readonly DbGiaPha _context;
    public HoRepository(DbGiaPha context)
    {
        _context = context;
    }

    public async Task<Ho?> CreateHoAsync(string tenHo, string? moTa)
    {
        var ho = Ho.Create(tenHo, moTa);
        _context.Hos.Add(ho);
        await _context.SaveChangesAsync();
        return ho;
    }

    public async Task<Ho?> GetHoByIdAsync(Guid hoId)
    {
        return await _context.Hos.FindAsync(hoId);
    }

    public async Task<Ho?> GetHoByNameAsync(string tenHo)
    {
        return await _context.Hos.FirstOrDefaultAsync(h => h.TenHo == tenHo);
    }

    public async Task<Ho> UpdateHoAsync(Ho ho)
    {
        _context.Hos.Update(ho);
        await _context.SaveChangesAsync();
        return ho;
    }
}