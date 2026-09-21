using System;
using System.Threading.Tasks;
using System.Web.UI;

namespace Training.WebForms
{
    public partial class UiStateDemo : Page
    {
        private readonly ProductService productService = new ProductService();

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await LoadProducts();
            }
        }

        protected async void RefreshButton_Click(object sender, EventArgs e)
        {
            await LoadProducts();
        }

        private async Task LoadProducts()
        {
            LoadingPanel.Visible = true;
            EmptyPanel.Visible = false;
            ErrorPanel.Visible = false;
            ProductsGrid.Visible = false;
            RefreshButton.Enabled = false;

            try
            {
                var products = await productService.GetAllAsync();

                LoadingPanel.Visible = false;

                if (products.Count == 0)
                {
                    EmptyPanel.Visible = true;
                    return;
                }

                ProductsGrid.DataSource = products;
                ProductsGrid.DataBind();
                ProductsGrid.Visible = true;
            }
            catch
            {
                LoadingPanel.Visible = false;
                ErrorPanel.Visible = true;
            }
            finally
            {
                RefreshButton.Enabled = true;
            }
        }
    }
}
