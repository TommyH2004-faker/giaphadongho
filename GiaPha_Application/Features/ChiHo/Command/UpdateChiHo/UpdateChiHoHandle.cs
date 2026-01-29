using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using GiaPha_Application.Repository;
using MediatR;

namespace GiaPha_Application.Features.ChiHo.Command.UpdateChiHo;

public class UpdateChiHoHandle : IRequestHandler<UpdateChiHoCommand, Result<ChiHoResponse>>
{
    private readonly IChiHoRepository _chiHoRepository;
    public UpdateChiHoHandle(IChiHoRepository chiHoRepository)
    {
        _chiHoRepository = chiHoRepository;
    }
    public async Task<Result<ChiHoResponse>> Handle(UpdateChiHoCommand request, CancellationToken cancellationToken)
    {
        var chiHo = await _chiHoRepository.GetChiHoByIdAsync(request.IdHo);
        if(chiHo == null)
        {
            return Result<ChiHoResponse>.Failure(ErrorType.NotFound, "Chi họ không tồn tại");
        }
        if (chiHo.Data == null)
        {
            return Result<ChiHoResponse>.Failure(ErrorType.NotFound, "Dữ liệu chi họ không tồn tại");
        }
        chiHo.Data.Update(request.TenChiHo, request.IdHo, request.MoTa);
        var truongChi = await _chiHoRepository.GetThanhVienByIdAsync(request.TruongChiId);
        if(truongChi == null || truongChi.Data == null)
        {
            return Result<ChiHoResponse>.Failure(ErrorType.NotFound, "Trưởng chi không tồn tại");
        }
        chiHo.Data.AssignTruongChi(truongChi.Data);
        await _chiHoRepository.UpdateChiHoAsync(chiHo.Data);
        await _chiHoRepository.SaveChangesAsync();
        var chiHoResponse = new ChiHoResponse
        {
            Id = chiHo.Data.Id,
            TenChiHo = chiHo.Data.TenChiHo,
            MoTa = chiHo.Data.MoTa,
            IdHo = chiHo.Data.IdHo,
            TruongChiId = chiHo.Data.TruongChiId
        };
        return Result<ChiHoResponse>.Success(chiHoResponse);   
    }
}
