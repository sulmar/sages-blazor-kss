using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Training.Blazor.Abstractions;

namespace Training.Blazor.Models;

public sealed class ProductListItem : BaseEntity
{
    //[Required(ErrorMessage = "Nazwa jest wymagana"), StringLength(20, MinimumLength = 3)]
    //[RegularExpression(@"^S.*", ErrorMessage = "Nazwa powinna zaczynac od litery S")]
    public string Name { get; set; }

    [Range(0.01, 1000)]
    //[CustomValidation(typeof(CustomValidator), nameof(CustomValidator.ValidatePrice))]    
    [Price]
    public decimal Price { get; set; }
}

public static class CustomValidator
{
    public static ValidationResult? ValidatePrice(
        decimal price,
        ValidationContext context)
    {
        if (price <= 0)
        {
            return new ValidationResult("Cena musi być większa od zera.", new[] { context.MemberName! });
        }

        if (decimal.Round(price, 2) != price)
        {
            return new ValidationResult("Cena może mieć maksymalnie 2 miejsca po przecinku.", new[] { context.MemberName! });
        }

        return ValidationResult.Success;
    }
}

public sealed class PriceAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(
        object? value,
        ValidationContext validationContext)
    {
        if (value is null)
            return ValidationResult.Success;

        if (value is decimal price)
            return CustomValidator.ValidatePrice(price, validationContext);
        
        return new ValidationResult(
            "Atrybut Price wymaga właściwości typu decimal.");
    }
}