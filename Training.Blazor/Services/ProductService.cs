using Training.Blazor.Models;

namespace Training.Blazor.Services;

public class ProductService
{
    private readonly IReadOnlyList<ProductListItem> products;

    public ProductService()
    {
        products = new List<ProductListItem>
            {
                new ProductListItem
                {
                    Id = 1,
                    Name = "Keyboard",
                    Price = 149.99m
                },
                new ProductListItem
                {
                    Id = 2,
                    Name = "Mouse",
                    Price = 79.99m
                },
                new ProductListItem
                {
                    Id = 3,
                    Name = "Monitor",
                    Price = 1299.00m
                }
            };
    }

    public IReadOnlyList<ProductListItem> GetProducts()
    {
        return products;
    }

    public ProductListItem? GetProductById(int id)
    {
        return products.SingleOrDefault(p=>p.Id == id);
    }

}
