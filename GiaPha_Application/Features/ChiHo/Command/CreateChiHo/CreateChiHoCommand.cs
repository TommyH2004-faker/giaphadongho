using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using MediatR;

namespace GiaPha_Application.Features.ChiHo.Command.CreateChiHo;
public record CreateChiHoCommand : IRequest<Result<ChiHoResponse>>
{
    public Guid IdHo { get; init; }
    public string TenChiHo { get; init; } = null!;
    public string? MoTa { get; init; }
    public  Guid TruongChiId { get; init; }
}