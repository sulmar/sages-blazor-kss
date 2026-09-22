using Bogus;
using Training.Blazor.Abstractions;
using Training.Blazor.Models;

namespace Training.Blazor.Services;

public class FakeProductService : FakeEntityService<ProductListItem>, IProductService
{
    public FakeProductService(Faker<ProductListItem> faker) : base(faker)
    {
    }
}
