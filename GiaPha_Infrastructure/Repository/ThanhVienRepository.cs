using GiaPha_Application.Common;
using GiaPha_Application.Repository;
using GiaPha_Domain.Entities;
using GiaPha_Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace GiaPha_Infrastructure.Repository;
public class ThanhVienRepository : IThanhVienRepository
{
    private readonly DbGiaPha _context;
    public ThanhVienRepository(DbGiaPha context)
    {
        _context = context;
    }

    public async Task<Result<ThanhVien?>> CreateThanhVienAsync(ThanhVien thanhVien)
    {
        _context.ThanhViens.Add(thanhVien);
        await _context.SaveChangesAsync();
        return Result<ThanhVien?>.Success(thanhVien);
    }

    public async Task<Result<bool>> DeleteThanhVienAsync(Guid id)
    {
        var thanhVien = await _context.ThanhViens.FindAsync(id);
        if (thanhVien == null)
        {
            return Result<bool>.Failure(ErrorType.NotFound, "Thành viên không tồn tại");
        }
        _context.ThanhViens.Remove(thanhVien);
        await _context.SaveChangesAsync();
        return Result<bool>.Success(true);
    }

    public async  Task<Result<IEnumerable<ThanhVien>>> GetAllThanhVienAsync()
    {
        var thanhViens = await _context.ThanhViens.ToListAsync();
        return Result<IEnumerable<ThanhVien>>.Success(thanhViens);
    }

    public async Task<Result<ThanhVien?>> GetThanhVienByIdAsync(Guid thanhVienId)
    {
        var thanhVien = await _context.ThanhViens.FindAsync(thanhVienId);
        return Result<ThanhVien?>.Success(thanhVien);
    }

    public async Task<Result<ThanhVien?>> GetThanhVienByNameAsync(string hoTen)
    {
        var thanhVien = await _context.ThanhViens.FirstOrDefaultAsync(t => t.HoTen == hoTen);
        return Result<ThanhVien?>.Success(thanhVien);
    }

    public async Task<Result<List<ThanhVien>>> GetThanhVienByEmailAsync(string email)
    {
       throw new NotImplementedException(); 
    }

    public async Task<Result<List<ThanhVien>>> GetThanhVienByUserIdAsync(Guid userId)
    {
       throw new NotImplementedException();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<Result<ThanhVien>> UpdateThanhVienAsync(ThanhVien thanhVien)
    {
        var existingThanhVien = await _context.ThanhViens.FindAsync(thanhVien.Id);
        if (existingThanhVien == null)
        {
            return Result<ThanhVien>.Failure(ErrorType.NotFound, "Thành viên không tồn tại");
        }
        _context.ThanhViens.Update(thanhVien);
        await _context.SaveChangesAsync();
        return Result<ThanhVien>.Success(thanhVien);
    }

    public async Task<Result<ThanhVien?>> GetHoById(Guid conId)
    {
        var thanhVien = await _context.ThanhViens.FindAsync(conId);
        return Result<ThanhVien?>.Success(thanhVien);
    }
}