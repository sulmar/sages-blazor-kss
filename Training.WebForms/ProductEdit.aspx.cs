using System;
using System.Web.UI;

namespace Training.WebForms
{
    public partial class ProductEdit : Page
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
            int id = int.Parse(Request.QueryString["id"]);

            Product product = productService.GetById(id);

            product.Name = NameTextBox.Text;
            product.Price = decimal.Parse(PriceTextBox.Text);

            productService.Update(product);

            Response.Redirect("Products.aspx");
        }
    }
}
