using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Training.WebForms
{
    public partial class ProductList : System.Web.UI.Page
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
            //ProductsGrid.DataSource = GetProducts();
            //ProductsGrid.DataBind();


            ProductsRepeater.DataSource = GetProducts();
            ProductsRepeater.DataBind();
        }

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
}