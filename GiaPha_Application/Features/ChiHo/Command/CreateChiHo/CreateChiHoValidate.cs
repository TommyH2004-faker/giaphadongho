using FluentValidation;

namespace GiaPha_Application.Features.ChiHo.Command.CreateChiHo;
public class CreateChiHoValidate:AbstractValidator<CreateChiHoCommand>
{
    public CreateChiHoValidate()
    {
        RuleFor(x => x.IdHo).NotEmpty().WithMessage("IdHọ không được để trống");
        RuleFor(x => x.TenChiHo).NotEmpty().WithMessage("Tên Chi Họ không được để trống")
            .MaximumLength(100).WithMessage("Tên Chi Họ không được vượt quá 100 ký tự");
        RuleFor(x => x.MoTa).MaximumLength(500).WithMessage("Mô tả không được vượt quá 500 ký tự");
        RuleFor(x => x.IdHo).NotEmpty().WithMessage("IdHọ không được để trống");
    }
   
}