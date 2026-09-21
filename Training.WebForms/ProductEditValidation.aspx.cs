using System;
using System.Web.UI;

namespace Training.WebForms
{
    public partial class ProductEditValidation : Page
    {
        private readonly ProductService productService = new ProductService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["id"]);

                Product product = productService.GetById(id);

                NameTextBox.Text = product.Name;
                PriceTextBox.Text = product.Price.ToString();
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            Product product = new Product
            {
                Id = int.Parse(Request.QueryString["id"]),
                Name = NameTextBox.Text,
                Price = decimal.Parse(PriceTextBox.Text)
            };

            productService.Update(product);
        }
    }
}
