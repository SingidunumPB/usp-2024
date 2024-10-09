using FluentValidation;
using USP.Application.Common.Validators;

namespace USP.Application.Products.Commands;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Product).NotNull();
        RuleFor(x => x.Product).SetValidator(new ProductCreateDtoValidator());
    }
}