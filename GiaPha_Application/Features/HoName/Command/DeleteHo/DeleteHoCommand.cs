using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using MediatR;

namespace GiaPha_Application.Features.HoName.Command.DeleteHo;
public record DeleteHoCommand() : IRequest<Result<HoResponse>>
{
    public Guid Id { get; init; }
}