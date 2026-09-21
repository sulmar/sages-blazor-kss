namespace Training.Blazor.Components.Pages;
public partial class ProductList
{
    private IReadOnlyList<ProductListItem> products;
    
   
    private static IReadOnlyList<ProductListItem> GetProducts()
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

    public sealed class ProductListItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }

}
