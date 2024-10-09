using FluentValidation;
using USP.Application.Common.Dto;

namespace USP.Application.Common.Validators;

public class EditUserDtoValidator : AbstractValidator<EditUserDto>
{
    public EditUserDtoValidator()
    {
        RuleFor(x => x.FirstName).MinimumLength(3);
        RuleFor(x => x.FirstName).MaximumLength(15);
        RuleFor(x => x.LastName).MaximumLength(15);
        RuleFor(x => x.LastName).MinimumLength(3);
        RuleFor(x => x.Email).MaximumLength(150);
        RuleFor(x => x.Email).MinimumLength(3);
    }
}