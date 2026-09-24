using Training.Blazor.Models;

namespace Training.Blazor.Abstractions;

// Kontrakt operacji na encji: lista, odczyt, zapis, dodanie.
public interface IEntityService<T>
    where T : BaseEntity
{
    IList<T> GetAll();
    T? GetById(int id);
    void Update(T entity);
    void Add(T entity);
}
