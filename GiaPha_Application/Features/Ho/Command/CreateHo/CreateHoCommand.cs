using GiaPha_Application.Common;
using MediatR;

namespace GiaPha_Application.Features.Ho.Command.CreateHo;
public record CreateHoCommand() : IRequest<Result<Guid>>
{
    public string TenHo { get; init; } = null!;
    public string? MoTa { get; init; }
}