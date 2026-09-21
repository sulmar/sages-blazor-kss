using System;
using System.Linq;
using System.Web.UI;

namespace Training.WebForms
{
    public partial class Products : Page
    {
        private readonly ProductService productService = new ProductService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            var maxPrice = (decimal?)Session["MaxPrice"];

            var products = productService.GetProducts();

            if (maxPrice.HasValue)
            {
                products = products
                    .Where(x => x.Price <= maxPrice.Value)
                    .ToList();
            }

            ProductsGrid.DataSource = products;
            ProductsGrid.DataBind();
        }
    }
}
