using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using GiaPha_Application.Repository;
using MediatR;
using GiaPha_Domain.Entities;
namespace GiaPha_Application.Features.ThanhVien.Command.Create;
public class CreateThanhVienHandle : IRequestHandler<CreateThanhVienCommand, Result<ThanhVienResponse>>
{
    private readonly IThanhVienRepository _thanhVienRepository;
    private readonly IChiHoRepository _chiHoRepository;
    private readonly IHoRepository _hoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateThanhVienHandle(IThanhVienRepository thanhVienRepository, IChiHoRepository chiHoRepository, IHoRepository hoRepository, IUnitOfWork unitOfWork)
    {
        _thanhVienRepository = thanhVienRepository;
        _chiHoRepository = chiHoRepository;
        _hoRepository = hoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ThanhVienResponse>> Handle(CreateThanhVienCommand request, CancellationToken cancellationToken)
    {
        var ho = await _hoRepository.GetHoByIdAsync(request.HoId);
    if (ho == null || ho.Data == null)
    {
        return Result<ThanhVienResponse>.Failure(ErrorType.Validation, "Họ không tồn tại");
    }

    // Kiểm tra ChiHoId có thuộc HoId không (nếu có ChiHoId)
    if (request.ChiHoId.HasValue)
    {
        var chiHo = await _chiHoRepository.GetChiHoByIdAsync(request.ChiHoId.Value);
        if (chiHo == null || chiHo.Data == null || chiHo.Data.HoId != request.HoId)
        {
            return Result<ThanhVienResponse>.Failure(ErrorType.Validation, "Chi họ không thuộc họ này");
        }
    }
    
       var thanhVien = GiaPha_Domain.Entities.ThanhVien.Create(
        request.HoTen,
        request.GioiTinh,
        request.NgaySinh,
        request.NoiSinh,
        request.TieuSu,
        request.ChiHoId,
        request.TrangThai,
        request.HoId
        );
        // check hoid exists
        var createdThanhVien = await _thanhVienRepository.CreateThanhVienAsync(thanhVien);
        
        await _unitOfWork.SaveChangesAsync();

        if (createdThanhVien.Data == null)
        {
            return Result<ThanhVienResponse>.Failure(ErrorType.Validation, "Tạo thành viên thất bại , vui lòng kiểm tra lại thông tin");
        }
        var thanhVienResponse = new ThanhVienResponse
        {
           Id = createdThanhVien.Data.Id,
           HoTen = createdThanhVien.Data.HoTen,
            GioiTinh = createdThanhVien.Data.GioiTinh,
            NgaySinh = createdThanhVien.Data.NgaySinh,
            NoiSinh = createdThanhVien.Data.NoiSinh!,
            TieuSu = createdThanhVien.Data.TieuSu,
            ChiHoId = createdThanhVien.Data.ChiHoId,
            TrangThai = createdThanhVien.Data.TrangThai,
            HoId = createdThanhVien.Data.HoId
        };

        return Result<ThanhVienResponse>.Success(thanhVienResponse);
    }
} 