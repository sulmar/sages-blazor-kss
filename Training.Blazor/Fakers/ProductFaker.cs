using Bogus;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Training.Blazor.Models;

namespace Training.Blazor.Fakers;

public class ProductFaker : Faker<ProductListItem>
{
    public ProductFaker()
    {
        RuleFor(p => p.Id, f => f.IndexFaker + 1);
        RuleFor(p => p.Name, f => f.Commerce.ProductName());
        RuleFor(p => p.Price, f => Math.Round(f.Random.Decimal(10, 500), 2));
    }
}
