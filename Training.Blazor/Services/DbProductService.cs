using Bogus;
using Training.Blazor.Abstractions;
using Training.Blazor.Models;

namespace Training.Blazor.Services;

public class DbProductService : IProductService
{
    // TODO: Change to DbContext
    private readonly IReadOnlyList<ProductListItem> products;

    public DbProductService(Faker<ProductListItem> faker)
    {
        products = faker.Generate(100);
    }

    public IReadOnlyList<ProductListItem> GetAll()
    {
        return products;
    }

    public ProductListItem? GetById(int id)
    {
        return products.SingleOrDefault(p => p.Id == id);
    }
}