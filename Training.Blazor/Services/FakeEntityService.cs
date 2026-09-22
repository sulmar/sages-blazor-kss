using Bogus;
using Training.Blazor.Models;

namespace Training.Blazor.Services;

public abstract class FakeEntityService<T> 
    where T : BaseEntity
{
    private readonly IReadOnlyList<T> entities;

    public FakeEntityService(Faker<T> faker)
    {
        entities = faker.Generate(100);
    }

    public IReadOnlyList<T> GetAll()
    {
        return entities;
    }

    public T? GetById(int id)
    {
        return entities.SingleOrDefault(p => p.Id == id);
    }
}
