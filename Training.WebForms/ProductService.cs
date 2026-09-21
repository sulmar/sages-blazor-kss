using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.WebForms
{
    public class ProductService
    {
        private static readonly List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Keyboard",
                Price = 149.99m
            },
            new Product
            {
                Id = 2,
                Name = "Mouse",
                Price = 79.99m
            },
            new Product
            {
                Id = 3,
                Name = "Monitor",
                Price = 1299.00m
            }
        };

        public IReadOnlyList<Product> GetProducts()
        {
            return products;
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            await Task.Delay(1500);

            return products;
        }

        public Product GetById(int id)
        {
            return products.First(product => product.Id == id);
        }

        public void Create(Product product)
        {
            product.Id = products.Max(item => item.Id) + 1;
            products.Add(product);
        }

        public void Update(Product product)
        {
            Product existing = GetById(product.Id);
            existing.Name = product.Name;
            existing.Price = product.Price;
        }
    }
}
