using Training.Blazor.Models;

namespace Training.Blazor.Abstractions;

public interface IEntityService<T>
    where T : BaseEntity
{
    IReadOnlyList<T> GetAll();
    T? GetById(int id);
}
