using Training.Blazor.Models;

namespace Training.Blazor.Services;

public class ProductService
{
    public IReadOnlyList<ProductListItem> GetProducts()
    {
        return new List<ProductListItem>
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
}
