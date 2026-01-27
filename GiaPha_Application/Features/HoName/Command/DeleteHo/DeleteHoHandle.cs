using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using GiaPha_Application.Repository;
using MediatR;

namespace GiaPha_Application.Features.HoName.Command.DeleteHo;

public class DeleteHoHandle 
    : IRequestHandler<DeleteHoCommand, Result<HoResponse>>
{
    private readonly IHoRepository _hoRepository;

    public DeleteHoHandle(IHoRepository hoRepository)
    {
        _hoRepository = hoRepository;
    }

    public async Task<Result<HoResponse>> Handle(DeleteHoCommand request,CancellationToken cancellationToken)
    {
        var ho = await _hoRepository.GetHoByIdAsync(request.Id);

        if (ho == null)
        {
            return Result<HoResponse>.Failure(
                ErrorType.NotFound,
                "Họ không tồn tại"
            );
        }

        var deleted = await _hoRepository.DeleteHoAsync(request.Id);

        if (!deleted)
        {
            return Result<HoResponse>.Failure(
                ErrorType.Failure,
                "Xóa họ thất bại"
            );
        }

        return Result<HoResponse>.Success(
            new HoResponse
            {
                TenHo = ho.TenHo,
                MoTa = ho.MoTa
            },
            $"Đã xóa thành công họ: {ho.TenHo}"
        );
    }
}
