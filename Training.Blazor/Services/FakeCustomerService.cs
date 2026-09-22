using Bogus;
using Training.Blazor.Abstractions;
using Training.Blazor.Models;

namespace Training.Blazor.Services;

public class FakeCustomerService : FakeEntityService<CustomerListItem>, ICustomerService
{
    public FakeCustomerService(Faker<CustomerListItem> faker) : base(faker)
    {
    }
}
