using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using GiaPha_Domain.Enums;
using MediatR;

namespace GiaPha_Application.Features.ThanhVien.Command.Create;
public record CreateThanhVienCommand() : IRequest<Result<ThanhVienResponse>>
{
    public string HoTen { get; init; } = null!;
    public string Email { get; init; } = null!; 
    public GioiTinh GioiTinh { get; init; }
    public DateTime NgaySinh { get; init; }
    public string NoiSinh { get; init; } = null!;
    public int DoiThu { get; init; }
    public Guid? ChiHoId { get; init; }
    public string? TieuSu { get; init; }
}