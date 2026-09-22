using Bogus;
using Training.Blazor.Abstractions;
using Training.Blazor.Models;

namespace Training.Blazor.Services;

public class FakeProductService : IProductService
{
    private readonly IReadOnlyList<ProductListItem> products;

    public FakeProductService(Faker<ProductListItem> faker)
    {
        products = faker.Generate(100);     
    }

    public IReadOnlyList<ProductListItem> GetProducts()
    {
        return products;
    }

    public ProductListItem? GetProductById(int id)
    {
        return products.SingleOrDefault(p=>p.Id == id);
    }

}
