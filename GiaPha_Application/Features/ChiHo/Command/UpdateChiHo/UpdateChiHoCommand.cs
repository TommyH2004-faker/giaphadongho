using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using MediatR;

namespace GiaPha_Application.Features.ChiHo.Command.UpdateChiHo;
public record UpdateChiHoCommand : IRequest<Result<ChiHoResponse>>
{
    public string TenChiHo { get; init; } = null!;
    public string? MoTa { get; init; }
    public Guid TruongChiId { get; init; }
    public Guid IdHo { get; init; }
}