using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using MediatR;

namespace GiaPha_Application.Features.HoName.Command.CreateHo;
public record CreateHoCommand : IRequest<Result<HoResponse>>
{
    public string TenHo { get; init; } = null!;
    public string? MoTa { get; init; }
}