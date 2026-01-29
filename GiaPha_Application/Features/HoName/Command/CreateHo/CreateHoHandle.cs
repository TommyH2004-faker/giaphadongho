using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using GiaPha_Application.Repository;
using MediatR;

namespace GiaPha_Application.Features.HoName.Command.CreateHo;

public class CreateHoHandle : IRequestHandler<CreateHoCommand, Result<HoResponse>>
{
    private readonly IHoRepository _hoRepository;
    public CreateHoHandle(IHoRepository hoRepository)
    {
        _hoRepository = hoRepository;
    }
    public async Task<Result<HoResponse>> Handle(CreateHoCommand request, CancellationToken cancellationToken)
    {
        var existingHo = await _hoRepository.GetHoByNameAsync(request.TenHo);
        if (existingHo != null)
        {
            return Result<HoResponse>.Failure(ErrorType.Conflict, "Họ đã tồn tại");
        }
        var ho = await _hoRepository.CreateHoAsync(request.TenHo, request.MoTa);
        if (ho == null)
        {
            return Result<HoResponse>.Failure(ErrorType.Failure ,"Tạo Họ thất bại");
        }
        if(ho.Data == null)
        {
            return Result<HoResponse>.Failure(ErrorType.Failure, "Dữ liệu Họ không tồn tại");
        }
        return Result<HoResponse>.Success(new HoResponse { TenHo = ho.Data.TenHo, MoTa = ho.Data.MoTa });
    }
}