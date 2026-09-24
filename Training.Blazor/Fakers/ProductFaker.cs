using Bogus;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Training.Blazor.Models;

namespace Training.Blazor.Fakers;

// Reguły losowych produktów dla Bogus.
public class ProductFaker : Faker<ProductListItem>
{
    public ProductFaker()
    {
        // Id od 1 w górę, zgodnie z kolejnością generowania.
        RuleFor(p => p.Id, f => f.IndexFaker + 1);
        // Losowa nazwa produktu.
        RuleFor(p => p.Name, f => f.Commerce.ProductName());
        // Cena 10–500, zaokrąglona do dwóch miejsc.
        RuleFor(p => p.Price, f => Math.Round(f.Random.Decimal(10, 500), 2));
    }
}
