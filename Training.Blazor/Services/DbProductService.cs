using Bogus;
using Training.Blazor.Abstractions;
using Training.Blazor.Models;

namespace Training.Blazor.Services;

// Szkic serwisu opartego o bazę — na razie dane z Faker.
public class DbProductService : IProductService
{
    // TODO: Change to DbContext
    // Lista tylko do odczytu wygenerowana przy starcie.
    private readonly IReadOnlyList<ProductListItem> products;

    public DbProductService(Faker<ProductListItem> faker)
    {
        products = faker.Generate(100);
    }

    public void Add(ProductListItem entity)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<ProductListItem> GetAll()
    {
        return products;
    }

    public ProductListItem? GetById(int id)
    {
        return products.SingleOrDefault(p => p.Id == id);
    }

    public void Update(ProductListItem entity)
    {
        throw new NotImplementedException();
    }

    // Jawna implementacja interfejsu — inna sygnatura niż publiczne GetAll.
    IList<ProductListItem> IEntityService<ProductListItem>.GetAll()
    {
        throw new NotImplementedException();
    }
}
