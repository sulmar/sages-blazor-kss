using Bogus;
using Training.Blazor.Abstractions;
using Training.Blazor.Models;

namespace Training.Blazor.Services;

public abstract class FakeEntityService<T>  : IEntityService<T>
    where T : BaseEntity
{
    private readonly IList<T> entities;

    public FakeEntityService(Faker<T> faker)
    {
        entities = faker.Generate(100);
    }

    public void Add(T entity)
    {
        var id = entities.Max(e=>e.Id);

        entity.Id = ++id;

        entities.Add(entity);
    }

    public IList<T> GetAll()
    {
        return entities;
    }

    public T? GetById(int id)
    {
        return entities.SingleOrDefault(p => p.Id == id);
    }

    public void Update(T entity)
    {
        T? e = GetById(entity.Id);

        e = entity;
    }
}
