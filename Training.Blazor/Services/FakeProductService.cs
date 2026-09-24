using Bogus;
using Training.Blazor.Abstractions;
using Training.Blazor.Models;

namespace Training.Blazor.Services;

// Konkretny serwis produktów oparty na danych w pamięci.
public class FakeProductService : FakeEntityService<ProductListItem>, IProductService
{
    public FakeProductService(Faker<ProductListItem> faker) : base(faker)
    {
    }
}
