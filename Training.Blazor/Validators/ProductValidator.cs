using FluentValidation;
using Training.Blazor.Models;

namespace Training.Blazor.Validators;

// Reguły FluentValidation dla formularza produktu.
public class ProductValidator : AbstractValidator<ProductListItem>
{
    public ProductValidator()
    {
        // Nazwa: niepusta, 3–20 znaków, zaczyna się od S. Stop przerywa przy pierwszym błędzie.
        RuleFor(x => x.Name).Cascade(CascadeMode.Stop).NotEmpty().Length(3, 20).Matches(@"^S.*").WithName("Nazwa");
        // Cena większa od zera i nie wyższa niż 1000.
        RuleFor(x => x.Price).GreaterThan(0).LessThanOrEqualTo(1000).WithName("Cena");
    }
}
