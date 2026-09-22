using Training.Blazor.Models;

namespace Training.Blazor.Abstractions;

public interface IEntityService<T>
    where T : BaseEntity
{
    IList<T> GetAll();
    T? GetById(int id);
    void Update(T entity);
    void Add(T entity);
}
