using System.Collections.Generic;
using System.Linq;

namespace WebFormsApp
{
    public class CustomerPage
    {
        public List<Customer> Items { get; set; } = new List<Customer>();

        public int TotalCount { get; set; }
    }
}
