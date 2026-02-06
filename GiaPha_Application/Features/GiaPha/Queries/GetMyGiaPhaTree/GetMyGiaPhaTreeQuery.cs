using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using MediatR;

namespace GiaPha_Application.Features.GiaPha.Queries.GetMyGiaPhaTree;

public class GetMyGiaPhaTreeQuery : IRequest<Result<GiaPhaTreeResponse>>
{
    public Guid UserId { get; set; }
    public int MaxLevel { get; set; } = 10;
    public bool IncludeNuGioi { get; set; } = true;
}
