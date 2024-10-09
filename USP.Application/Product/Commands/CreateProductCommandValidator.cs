using FluentValidation;
using USP.Domain.Enums;
using USP.Domain.Extensions;

namespace USP.Application.Product.Commands;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Product).NotNull();
        RuleFor(x => x.Product.Name).MinimumLength(3);
        RuleFor(x => x.Product.Name).MaximumLength(15);
        RuleFor(x => x.Product.Description).MaximumLength(150);
        RuleFor(x => x.Product.Description).MinimumLength(15);
        RuleFor(x => x.Product.Price).GreaterThan(0m);
        RuleFor(x => x.Product.Price).LessThanOrEqualTo(50000m);
        RuleFor(x => x.Product.Category).NotNull();

        RuleFor(x => x.Product.Category).Must(t => Category.TryFromValue(t, out _))
            .WithMessage($"Category must be in list of: {EnumExtensions.ValidCategoryList}");
    }
}