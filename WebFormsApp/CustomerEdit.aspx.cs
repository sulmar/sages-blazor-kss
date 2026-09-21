using System;
using System.Threading.Tasks;
using System.Web.UI;

namespace WebFormsApp
{
    public partial class CustomerEdit : Page
    {
        private readonly CustomerService _customerService =
            new CustomerService();

        protected async void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!IsPostBack)
            {
                var id = int.Parse(Request.QueryString["id"]);

                var customer =
                    await _customerService.GetAsync(id);

                NameTextBox.Text = customer.Name;
                EmailTextBox.Text = customer.Email;
            }
        }

        protected async void SaveButton_Click(
            object sender,
            EventArgs e)
        {
            if (!Page.IsValid)
                return;

            var id = int.Parse(Request.QueryString["id"]);

            var customer = new Customer
            {
                Id = id,
                Name = NameTextBox.Text,
                Email = EmailTextBox.Text
            };

            await _customerService.UpdateAsync(customer);

            Response.Redirect("Customers.aspx");
        }
    }
}
