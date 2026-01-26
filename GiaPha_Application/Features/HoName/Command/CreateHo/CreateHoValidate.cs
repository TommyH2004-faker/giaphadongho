using FluentValidation;

namespace GiaPha_Application.Features.HoName.Command.CreateHo;
public class CreateHoValidate : AbstractValidator<CreateHoCommand>
{
    public CreateHoValidate()
    {
        RuleFor(x => x.TenHo)
            .NotEmpty().WithMessage("Tên Họ không được để trống")
            .MaximumLength(100).WithMessage("Tên Họ không được vượt quá 100 ký tự");

        RuleFor(x => x.MoTa)
            .MaximumLength(500).WithMessage("Mô tả không được vượt quá 500 ký tự");
    }
}