
using GiaPha_Application.Common;
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

    public async Task<Result<Ho?>> CreateHoAsync(string tenHo, string? moTa)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<IEnumerable<Ho>>> GetAllHoAsync()
    {
        return Result<IEnumerable<Ho>>.Success(await _context.Hos.ToListAsync());
    }
    public async Task<Result<bool>> DeleteHoAsync(Guid id)
    {
        var ho = await _context.Hos.FindAsync(id);
        if (ho == null)
        {
            return Result<bool>.Failure(ErrorType.NotFound, "Hộ không tồn tại");
        }
        _context.Hos.Remove(ho);
        await _context.SaveChangesAsync();
        return Result<bool>.Success(true);   
    }
    public async Task<Result<Ho?>> GetHoByIdAsync(Guid hoId)
    {
        return Result<Ho?>.Success(await _context.Hos.FindAsync(hoId));
    }

    public async Task<Result<Ho?>> GetHoByNameAsync(string tenHo)
    {
        return Result<Ho?>.Success(await _context.Hos.FirstOrDefaultAsync(h => h.TenHo == tenHo));
    }

   

    public async Task<Result<Ho>> UpdateHoAsync(Ho ho)
    {
        _context.Hos.Update(ho);
        await _context.SaveChangesAsync();
        return Result<Ho>.Success(ho);
    }

    public async Task<Result<List<Ho>>> GetTop3HoAsync()
    {
        var top3Hos = await _context.Hos.Take(3).ToListAsync();
        return Result<List<Ho>>.Success(top3Hos);
    }

    public Task<Result<List<Ho>>> GetHosByThanhVienIdAsync(Guid thanhVienId)
    {
        throw new NotImplementedException();
    }
}