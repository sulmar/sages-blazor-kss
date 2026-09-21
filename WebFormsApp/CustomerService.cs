using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFormsApp
{
    public class CustomerService
    {
        private static readonly List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Jan Kowalski", Email = "jan@example.com" },
            new Customer { Id = 2, Name = "Anna Nowak", Email = "anna@example.com" },
            new Customer { Id = 3, Name = "Adam Kowalski", Email = "adam@example.com" },
            new Customer { Id = 4, Name = "Anna Kowalska", Email = "anna.k@example.com" },
            new Customer { Id = 5, Name = "Piotr Wiśniewski", Email = "piotr@example.com" },
            new Customer { Id = 6, Name = "Maria Lewandowska", Email = "maria@example.com" },
            new Customer { Id = 7, Name = "Tomasz Wójcik", Email = "tomasz@example.com" },
            new Customer { Id = 8, Name = "Katarzyna Kamińska", Email = "katarzyna@example.com" },
            new Customer { Id = 9, Name = "Michał Zieliński", Email = "michal@example.com" },
            new Customer { Id = 10, Name = "Ewa Szymańska", Email = "ewa@example.com" },
            new Customer { Id = 11, Name = "Paweł Woźniak", Email = "pawel@example.com" },
            new Customer { Id = 12, Name = "Magdalena Dąbrowska", Email = "magdalena@example.com" }
        };

        public async Task<List<Customer>> GetAllAsync()
        {
            await Task.Delay(1000);

            return customers.ToList();
        }

        public async Task<List<Customer>> SearchAsync(string search)
        {
            await Task.Delay(1000);

            return Filter(search).ToList();
        }

        public async Task<CustomerPage> GetPageAsync(
            string search,
            int page,
            int pageSize)
        {
            await Task.Delay(1000);

            List<Customer> filtered = Filter(search).ToList();

            return new CustomerPage
            {
                TotalCount = filtered.Count,
                Items = filtered
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()
            };
        }

        public async Task CreateAsync(Customer customer)
        {
            await Task.Delay(1000);

            customer.Id = customers.Count == 0
                ? 1
                : customers.Max(item => item.Id) + 1;

            customers.Add(customer);
        }

        public async Task<Customer> GetAsync(int id)
        {
            await Task.Delay(1000);

            Customer existing = customers.FirstOrDefault(item => item.Id == id);
            if (existing == null)
            {
                return null;
            }

            return new Customer
            {
                Id = existing.Id,
                Name = existing.Name,
                Email = existing.Email
            };
        }

        public async Task UpdateAsync(Customer customer)
        {
            await Task.Delay(1000);

            Customer existing = customers.First(item => item.Id == customer.Id);
            existing.Name = customer.Name;
            existing.Email = customer.Email;
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Delay(1000);

            customers.RemoveAll(item => item.Id == id);
        }

        private static IEnumerable<Customer> Filter(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return customers;
            }

            return customers.Where(customer =>
                customer.Name.IndexOf(search, StringComparison.CurrentCultureIgnoreCase) >= 0
                || customer.Email.IndexOf(search, StringComparison.CurrentCultureIgnoreCase) >= 0);
        }
    }
}
