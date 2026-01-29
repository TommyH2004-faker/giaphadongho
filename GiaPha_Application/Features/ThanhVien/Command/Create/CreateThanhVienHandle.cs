using GiaPha_Application.Common;
using GiaPha_Application.DTOs;
using GiaPha_Application.Repository;
using MediatR;

namespace GiaPha_Application.Features.ThanhVien.Command.Create;
public class CreateThanhVienHandle : IRequestHandler<CreateThanhVienCommand, Result<ThanhVienResponse>>
{
    private readonly IThanhVienRepository _thanhVienRepository;

    public CreateThanhVienHandle(IThanhVienRepository thanhVienRepository)
    {
        _thanhVienRepository = thanhVienRepository;
    }

    public async Task<Result<ThanhVienResponse>> Handle(CreateThanhVienCommand request, CancellationToken cancellationToken)
    {
       var thanhVien = GiaPha_Domain.Entities.ThanhVien.Create(
            request.HoTen,
            request.Email,
            request.GioiTinh,
            request.NgaySinh,
            request.NoiSinh,
            null,
            null,
            request.DoiThu,
            request.TieuSu,
            null,
            request.IdHo
        );
        // check trùng email 
        var existEmail = await _thanhVienRepository.GetThanhVienByNameAsync(request.HoTen);
        if (existEmail != null && existEmail.Data != null)
        {
            return Result<ThanhVienResponse>.Failure(ErrorType.Conflict, "Thành viên với email này đã tồn tại");
        }
        var createdThanhVien = await _thanhVienRepository.CreateThanhVienAsync(thanhVien);
        thanhVien.RaiseCreatedEvent();
        await _thanhVienRepository.SaveChangesAsync();

        if (createdThanhVien.Data == null)
        {
            return Result<ThanhVienResponse>.Failure(ErrorType.Validation, "Tạo thành viên thất bại , vui lòng kiểm tra lại thông tin");
        }
        var thanhVienResponse = new ThanhVienResponse
        {
            Id = createdThanhVien.Data.Id,
            HoTen = createdThanhVien.Data.HoTen,
            Email = request.Email,
            gioiTinh = createdThanhVien.Data.GioiTinh,
            NgaySinh = createdThanhVien.Data.NgaySinh ?? DateTime.MinValue,
            NoiSinh = createdThanhVien.Data.NoiSinh ?? string.Empty,
            ngayMat = createdThanhVien.Data.NgayMat,
            noiMat = createdThanhVien.Data.NoiMat,
            DoiThu = createdThanhVien.Data.DoiThu,
            TieuSu = createdThanhVien.Data.TieuSu,
            AnhDaiDien = createdThanhVien.Data.AnhDaiDien,
            ChiHoId = createdThanhVien.Data.ChiHoId
        };

        return Result<ThanhVienResponse>.Success(thanhVienResponse);
    }
} 