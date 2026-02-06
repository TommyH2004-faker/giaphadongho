using GiaPha_Application.Common;
using GiaPha_Application.Repository;
using GiaPha_Domain.Entities;
using GiaPha_Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace GiaPha_Infrastructure.Repository;

public class AuthRepository : IAuthRepository
{
    private readonly DbGiaPha _context;
    public AuthRepository(DbGiaPha context)
    {
        _context = context;
    }

    public async Task<Result<TaiKhoanNguoiDung>> AddUserAsync(TaiKhoanNguoiDung newUser)
    {
        _context.TaiKhoanNguoiDungs.Add(newUser);
        return Result<TaiKhoanNguoiDung>.Success(newUser);
    }

    public async Task<Result<TaiKhoanNguoiDung>> CreateUserAsync(TaiKhoanNguoiDung user)
    {
        _context.TaiKhoanNguoiDungs.Add(user);
        return Result<TaiKhoanNguoiDung>.Success(user);
    }

    public async Task<Result<bool>> DeleteUserAsync(int id)
    {
        var user = await _context.TaiKhoanNguoiDungs.FindAsync(id);
        if (user == null)
        {
            return Result<bool>.Failure(ErrorType.NotFound, "User not found");
        }
        _context.TaiKhoanNguoiDungs.Remove(user);
        return Result<bool>.Success(true);
    }

    public async Task<Result<IEnumerable<TaiKhoanNguoiDung>>> GetAllUsersAsync()
    {
        var users = await _context.TaiKhoanNguoiDungs.ToListAsync();
        return Result<IEnumerable<TaiKhoanNguoiDung>>.Success(users);
    }

    public async Task<Result<TaiKhoanNguoiDung?>> GetUserByEmailAsync(string email)
    {
        var user = await _context.TaiKhoanNguoiDungs.FirstOrDefaultAsync(u => u.Email == email);
        return Result<TaiKhoanNguoiDung?>.Success(user);
    }

    public async Task<Result<TaiKhoanNguoiDung?>> GetUserByIdAsync(Guid id)
    {
        var user = await _context.TaiKhoanNguoiDungs.FindAsync(id);
        return Result<TaiKhoanNguoiDung?>.Success(user);
    }

    public async Task<Result<TaiKhoanNguoiDung?>> GetUserByUsernameAsync(string TenDangNhap)
    {
        var user = await _context.TaiKhoanNguoiDungs.FirstOrDefaultAsync(u => u.TenDangNhap == TenDangNhap);
        return Result<TaiKhoanNguoiDung?>.Success(user);
    }

   

    public async Task<Result<TaiKhoanNguoiDung>> UpdateUserAsync(TaiKhoanNguoiDung user)
    {
        _context.TaiKhoanNguoiDungs.Update(user);
        return Result<TaiKhoanNguoiDung>.Success(user);
    }

}