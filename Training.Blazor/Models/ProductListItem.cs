using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Training.Blazor.Abstractions;

namespace Training.Blazor.Models;

// Model wiersza produktu na liście i w formularzu.
public sealed class ProductListItem : BaseEntity
{
    // Walidacja DataAnnotations — tu wyłączona na rzecz FluentValidation.
    //[Required(ErrorMessage = "Nazwa jest wymagana"), StringLength(20, MinimumLength = 3)]
    //[RegularExpression(@"^S.*", ErrorMessage = "Nazwa powinna zaczynac od litery S")]
    public string Name { get; set; }

    // Cena musi mieścić się w podanym zakresie.
    [Range(0.01, 1000)]
    // Własna metoda walidacji — wariant zakomentowany.
    //[CustomValidation(typeof(CustomValidator), nameof(CustomValidator.ValidatePrice))]
    // Własny atrybut sprawdzający cenę.
    [Price]
    public decimal Price { get; set; }
}

// Metody walidacji wołane z atrybutu albo CustomValidation.
public static class CustomValidator
{
    public static ValidationResult? ValidatePrice(
        decimal price,
        ValidationContext context)
    {
        // Cena nie może być zerem ani ujemna.
        if (price <= 0)
        {
            return new ValidationResult("Cena musi być większa od zera.", new[] { context.MemberName! });
        }

        // Dopuszczalne są co najwyżej dwa miejsca po przecinku.
        if (decimal.Round(price, 2) != price)
        {
            return new ValidationResult("Cena może mieć maksymalnie 2 miejsca po przecinku.", new[] { context.MemberName! });
        }

        // Brak błędu.
        return ValidationResult.Success;
    }
}

// Atrybut walidacji podpinany nad właściwością Price.
public sealed class PriceAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(
        object? value,
        ValidationContext validationContext)
    {
        // Pusta wartość nie jest błędem tego atrybutu.
        if (value is null)
            return ValidationResult.Success;

        // Dla decimal woła wspólną regułę ceny.
        if (value is decimal price)
            return CustomValidator.ValidatePrice(price, validationContext);

        // Atrybut odrzuca inny typ właściwości.
        return new ValidationResult(
            "Atrybut Price wymaga właściwości typu decimal.");
    }
}
