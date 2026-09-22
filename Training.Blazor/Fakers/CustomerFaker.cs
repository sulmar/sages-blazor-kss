using Bogus;
using Training.Blazor.Models;

namespace Training.Blazor.Fakers;

public class CustomerFaker : Faker<CustomerListItem>
{
    public CustomerFaker()
    {
        RuleFor(p => p.Id, f => f.IndexFaker + 1);
        RuleFor(p => p.Name, f => f.Person.FullName);
        RuleFor(p => p.Email, (f, c) => $"{c.Name}@domain.com");
    }
}