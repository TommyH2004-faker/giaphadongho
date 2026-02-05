using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using GiaPha_Application.Repository;
using MediatR;

namespace GiaPha_Application.Features.HoName.Queries.GetThuyToHoById;
public class GetThuyToHoHandle : IRequestHandler<GetThuyToHoByIdQuery, Result<HoResponse>>
{
    private readonly IHoRepository _hoRepository;

    public GetThuyToHoHandle(IHoRepository hoRepository)
    {
        _hoRepository = hoRepository;
    }

    public async Task<Result<HoResponse>> Handle(GetThuyToHoByIdQuery request, CancellationToken cancellationToken)
    {
        var hoResult = await _hoRepository.GetHoByThuyToIdAsync(request.ThuyToId);
        if (hoResult == null || hoResult.Data == null)
        {
            return Result<HoResponse>.Failure(ErrorType.NotFound, "Dữ liệu Họ không tồn tại");
        }

        var ho = hoResult.Data;
        var hoResponse = new HoResponse
        {
            Id = ho.Id,
            TenHo = ho.TenHo,
            MoTa = ho.MoTa,
            HinhAnh = ho.HinhAnh,
            QueQuan = ho.QueQuan,
            ThuyToId = ho.ThuyToId
        };

        return Result<HoResponse>.Success(hoResponse);
    }
}