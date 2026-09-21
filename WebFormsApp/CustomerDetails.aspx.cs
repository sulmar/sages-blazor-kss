using System;
using System.Threading.Tasks;
using System.Web.UI;

namespace WebFormsApp
{
    public partial class CustomerDetails : Page
    {
        private readonly CustomerService _customerService =
            new CustomerService();

        protected async void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!IsPostBack)
            {
                await LoadCustomer();
            }
        }

        protected async void RetryButton_Click(
            object sender,
            EventArgs e)
        {
            await LoadCustomer();
        }

        private async Task LoadCustomer()
        {
            LoadingPanel.Visible = true;
            CustomerPanel.Visible = false;
            NotFoundPanel.Visible = false;
            ErrorPanel.Visible = false;

            try
            {
                var id = int.Parse(Request.QueryString["id"]);

                var customer =
                    await _customerService.GetAsync(id);

                if (customer == null)
                {
                    NotFoundPanel.Visible = true;
                    return;
                }

                NameLabel.Text = customer.Name;
                EmailLabel.Text = customer.Email;
                CustomerPanel.Visible = true;
            }
            catch
            {
                ErrorPanel.Visible = true;
            }
            finally
            {
                LoadingPanel.Visible = false;
            }
        }
    }
}
