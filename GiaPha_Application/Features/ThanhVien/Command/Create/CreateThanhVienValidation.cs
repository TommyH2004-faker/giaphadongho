
using FluentValidation;

namespace GiaPha_Application.Features.ThanhVien.Command.Create;
public class CreateThanhVienValidation: AbstractValidator<CreateThanhVienCommand>
{
    public CreateThanhVienValidation()
    {
        RuleFor(x => x.HoTen)
            .NotEmpty().WithMessage("Họ tên không được để trống")
            .MaximumLength(100).WithMessage("Họ tên không được vượt quá 100 ký tự");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email không được để trống")
            .EmailAddress().WithMessage("Email không hợp lệ")
            .MaximumLength(100).WithMessage("Email không được vượt quá 100 ký tự");

        RuleFor(x => x.NgaySinh)
            .LessThan(DateTime.Now).WithMessage("Ngày sinh phải nhỏ hơn ngày hiện tại");

        RuleFor(x => x.NoiSinh)
            .NotEmpty().WithMessage("Nơi sinh không được để trống")
            .MaximumLength(200).WithMessage("Nơi sinh không được vượt quá 200 ký tự");

        RuleFor(x => x.DoiThu)
            .GreaterThan(0).WithMessage("Đời thứ phải lớn hơn 0");
        RuleFor(x => x.IdHo)
            .NotEmpty().WithMessage("IdHo không được để trống");
    }
}