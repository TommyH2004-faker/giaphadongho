using GiaPha_Application.Common;
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

    public async Task<Result<ChiHo?>> CreateChiHoAsync(ChiHo chiHo)
    {
        _context.ChiHos.Add(chiHo);
        await  _context.SaveChangesAsync();
        return Result<ChiHo?>.Success(chiHo);
    }

    public async Task<Result<bool>> DeleteChiHoAsync(Guid id)
    {
        var chiHo = await _context.ChiHos.FindAsync(id);
        if (chiHo == null)
        {
            return Result<bool>.Failure(ErrorType.NotFound, "Chi họ không tồn tại");
        }
        _context.ChiHos.Remove(chiHo);
        await _context.SaveChangesAsync();
        return Result<bool>.Success(true);
    }

    public async Task<Result<IEnumerable<ChiHo>>> GetAllChiHoAsync()
    {
        return Result<IEnumerable<ChiHo>>.Success(await _context.ChiHos.ToListAsync());
    }

    public async Task<Result<ChiHo?>> GetChiHoByIdAsync(Guid chiHoId)
    {
        var chiHo = await _context.ChiHos.FindAsync(chiHoId);
        return Result<ChiHo?>.Success(chiHo);
    }

    public async Task<Result<ChiHo?>> GetChiHoByNameAsync(string tenChiHo)
    {
        var chiHo = await _context.ChiHos.FirstOrDefaultAsync(c => c.TenChiHo == tenChiHo);
        return Result<ChiHo?>.Success(chiHo);
    }

    public async Task<Result<ThanhVien>> GetThanhVienByIdAsync(Guid truongChiId)
    {
        var thanhVien = await _context.ThanhViens.FindAsync(truongChiId);
        if (thanhVien == null)
        {
            return Result<ThanhVien>.Failure(ErrorType.NotFound, "Thành viên không tồn tại");
        }
        return Result<ThanhVien>.Success(thanhVien);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<Result<ChiHo>> Update(ChiHo chiHo)
    {
        _context.ChiHos.Update(chiHo);
        await _context.SaveChangesAsync();
        return Result<ChiHo>.Success(chiHo);
    }

    public async Task<Result<ChiHo> > UpdateChiHoAsync(ChiHo chiHo)
    {
        _context.ChiHos.Update(chiHo);
        await _context.SaveChangesAsync();
        return Result<ChiHo>.Success(chiHo);
    }
}