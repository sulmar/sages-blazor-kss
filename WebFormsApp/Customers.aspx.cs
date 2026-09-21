using System;
using System.Threading.Tasks;
using System.Web.UI;

namespace WebFormsApp
{
    public partial class Customers : Page
    {
        private readonly CustomerService _customerService =
            new CustomerService();

        protected async void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!IsPostBack)
            {
                await LoadCustomers();
            }
        }

        protected async void RefreshButton_Click(
            object sender,
            EventArgs e)
        {
            await LoadCustomers();
        }

        private async Task LoadCustomers()
        {
            LoadingPanel.Visible = true;
            EmptyPanel.Visible = false;
            ErrorPanel.Visible = false;
            CustomersGrid.Visible = false;
            RefreshButton.Enabled = false;

            try
            {
                var customers =
                    await _customerService.GetAllAsync();

                if (customers.Count == 0)
                {
                    EmptyPanel.Visible = true;
                    return;
                }

                CustomersGrid.DataSource = customers;
                CustomersGrid.DataBind();
                CustomersGrid.Visible = true;
            }
            catch
            {
                ErrorPanel.Visible = true;
            }
            finally
            {
                LoadingPanel.Visible = false;
                RefreshButton.Enabled = true;
            }
        }
    }
}
