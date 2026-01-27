using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using GiaPha_Domain.Entities;

namespace GiaPha_Application.Repository;
public interface IHoRepository
{
    Task<Ho?> CreateHoAsync(string tenHo, string? moTa);
    Task<bool> DeleteHoAsync(Guid id);
    Task<IEnumerable<Ho>> GetAllHoAsync();
    Task<Ho?> GetHoByIdAsync(Guid hoId);
    Task<Ho?> GetHoByNameAsync(string tenHo);
    Task<Ho> UpdateHoAsync(Ho ho);
}