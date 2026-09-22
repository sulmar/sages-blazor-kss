using Training.Blazor.Models;

namespace Training.Blazor.Abstractions;

public interface IProductService
{
    IReadOnlyList<ProductListItem> GetProducts();
    ProductListItem? GetProductById(int id);
}
