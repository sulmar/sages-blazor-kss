using System;
using System.Web.UI;

namespace Training.WebForms
{
    public partial class ProductDetails : Page
    {
        private readonly ProductService productService = new ProductService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["id"]);

                Product product = productService.GetById(id);

                IdLabel.Text = product.Id.ToString();
                NameLabel.Text = product.Name;
                PriceLabel.Text = product.Price.ToString("C");
            }
        }
    }
}
