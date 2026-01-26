using GiaPha_Domain.Entities;

namespace GiaPha_Application.Repository;
public interface IHoRepository
{
    Task<Ho?> CreateHoAsync(string tenHo, string? moTa);
    Task<Ho?> GetHoByIdAsync(Guid hoId);
    // lay ten ra de kiem tra ton tai
    Task<Ho?> GetHoByNameAsync(string tenHo);
    Task<Ho> UpdateHoAsync(Ho ho);
}