using System;
using System.Web.UI;

namespace Training.WebForms
{
    public partial class ProductCreate : Page
    {
        private readonly ProductService productService = new ProductService();

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            var product = new Product
            {
                Name = NameTextBox.Text,
                Price = decimal.Parse(PriceTextBox.Text)
            };

            productService.Create(product);

            Response.Redirect("Products.aspx");
        }
    }
}
