using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using GiaPha_Application.Repository;
using MediatR;

namespace GiaPha_Application.Features.GiaPha.Queries.GetGiaPhaTree;

public class GetGiaPhaTreeHandler : IRequestHandler<GetGiaPhaTreeQuery, Result<GiaPhaTreeResponse>>
{
    private readonly IGiaPhaRepository _giaPhaRepository;

    public GetGiaPhaTreeHandler(IGiaPhaRepository giaPhaRepository)
    {
        _giaPhaRepository = giaPhaRepository;
    }

    public async Task<Result<GiaPhaTreeResponse>> Handle(GetGiaPhaTreeQuery request, CancellationToken cancellationToken)
    {
        var result = await _giaPhaRepository.BuildGiaPhaTreeAsync(request.HoId, request.MaxLevel, request.IncludeNuGioi);
        return result;
    }
}