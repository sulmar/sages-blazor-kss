using Bogus;
using Training.Blazor.Models;

namespace Training.Blazor.Services;

public class ProductService
{
    private readonly IReadOnlyList<ProductListItem> products;

    public ProductService(Faker<ProductListItem> faker)
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
