using Bogus;
using Training.Blazor.Abstractions;
using Training.Blazor.Models;

namespace Training.Blazor.Services;

// Dane produktów w pamięci, generowane przez Bogus.
public abstract class FakeEntityService<T> : IEntityService<T>
    where T : BaseEntity
{
    // Kolekcja trzymana w singletonie przez czas życia aplikacji.
    private readonly IList<T> entities;

    public FakeEntityService(Faker<T> faker)
    {
        // Sto losowych rekordów na start.
        entities = faker.Generate(100);
    }

    public void Add(T entity)
    {
        // Kolejne Id za maksymalnym istniejącym.
        var id = entities.Max(e => e.Id);

        entity.Id = ++id;

        entities.Add(entity);
    }

    public IList<T> GetAll()
    {
        return entities;
    }

    public T? GetById(int id)
    {
        // null, gdy brak rekordu o tym Id.
        return entities.SingleOrDefault(p => p.Id == id);
    }

    public void Update(T entity)
    {
        T? e = GetById(entity.Id);

        // Przypisanie lokalne — nie podmienia elementu w liście.
        e = entity;
    }
}
