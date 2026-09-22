using System.ComponentModel.DataAnnotations;

namespace Training.Blazor.Models;

public sealed class ProductListItem : BaseEntity
{
    [Required(ErrorMessage = "Nazwa jest wymagana"), StringLength(20, MinimumLength = 3)]
    [RegularExpression(@"^S.*", ErrorMessage = "Nazwa powinna zaczynac od litery S")]
    public string Name { get; set; }

    [Range(0.01, 1000)]
    //[CustomValidation()]
    [Currency]
    public decimal Price { get; set; }
}

public class CurrencyAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (decimal.TryParse(value.ToString(), out decimal currency))
        {
            return true;

        }

        return false;
    }
}