using FluentValidation;
using Training.Blazor.Models;

namespace Training.Blazor.Validators;

public class ProductValidator : AbstractValidator<ProductListItem>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name).Cascade(CascadeMode.Stop).NotEmpty().Length(3, 20).Matches(@"^S.*").WithName("Nazwa");
        RuleFor(x => x.Price).GreaterThan(0).LessThanOrEqualTo(1000).WithName("Cena");
    }
}
