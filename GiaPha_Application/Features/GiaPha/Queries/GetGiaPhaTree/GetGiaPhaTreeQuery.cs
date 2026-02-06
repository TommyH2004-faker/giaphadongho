using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using MediatR;

namespace GiaPha_Application.Features.GiaPha.Queries.GetGiaPhaTree;

public class GetGiaPhaTreeQuery : IRequest<Result<GiaPhaTreeResponse>>
{
    public Guid HoId { get; set; }
    public int MaxLevel { get; set; } = 10; // Giới hạn cấp độ
    public bool IncludeNuGioi { get; set; } = true; // Có bao gồm nữ giới không
}