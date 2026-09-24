using Training.Blazor.Models;

namespace Training.Blazor.Abstractions;

// Serwis produktów — te same operacje co IEntityService.
public interface IProductService : IEntityService<ProductListItem>
{
}
