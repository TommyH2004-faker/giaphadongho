using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using GiaPha_Application.Repository;
using MediatR;

namespace GiaPha_Application.Features.ChiHo.Command.CreateChiHo;
public class CreateChiHoHandle : IRequestHandler<CreateChiHoCommand, Result<ChiHoResponse>>
{
    private readonly IChiHoRepository _chiHoRepository;
    public CreateChiHoHandle(IChiHoRepository chiHoRepository)
    {
        _chiHoRepository = chiHoRepository;
    }
    public async Task<Result<ChiHoResponse>> Handle(CreateChiHoCommand request, CancellationToken cancellationToken)
    {
        var existingChiHo = await _chiHoRepository.GetChiHoByNameAsync(request.TenChiHo);
        if (existingChiHo != null)
        {
            return Result<ChiHoResponse>.Failure(ErrorType.Conflict, "Chi Họ đã tồn tại");
        }
        var chiHo = GiaPha_Domain.Entities.ChiHo.Create(request.TenChiHo, request.IdHo, request.MoTa);
        var createdChiHo = await _chiHoRepository.CreateChiHoAsync(chiHo);

        var chiHoResponse = new ChiHoResponse
        {
            Id = createdChiHo?.Id ?? Guid.Empty,
            IdHo = request.IdHo,
            TenChiHo = createdChiHo?.TenChiHo,
            MoTa = createdChiHo?.MoTa,
            TruongChiId = null // Mặc định là null khi tạo mới
        };

        return Result<ChiHoResponse>.Success(chiHoResponse);
    }
}