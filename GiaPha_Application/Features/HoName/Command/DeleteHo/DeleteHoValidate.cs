using FluentValidation;

namespace GiaPha_Application.Features.HoName.Command.DeleteHo;
public class DeleteHoValidate:AbstractValidator<DeleteHoCommand>
{
    public DeleteHoValidate()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id không được để trống");
    }
}