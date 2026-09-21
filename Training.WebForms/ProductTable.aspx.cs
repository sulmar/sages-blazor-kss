using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Training.WebForms
{
    public partial class ProductTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProducts();
            }
        }

        private void BindProducts()
        {
            ProductsGrid.DataSource = GetProducts();
            ProductsGrid.DataBind();
        }

        private static IReadOnlyList<Product> GetProducts()
        {
            return new List<Product>
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
        }
    }

}
