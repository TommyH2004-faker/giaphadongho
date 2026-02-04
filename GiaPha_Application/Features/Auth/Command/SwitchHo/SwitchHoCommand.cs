using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using MediatR;

namespace GiaPha_Application.Features.Auth.Command.SwitchHo;

public record SwitchHoCommand : IRequest<Result<LoginRespone>>
{
    public Guid UserId { get; init; }
    public Guid HoId { get; init; }
}