using System;
using System.Threading.Tasks;
using System.Web.UI;

namespace WebFormsApp
{
    public partial class CustomerCreate : Page
    {
        private readonly CustomerService _customerService =
            new CustomerService();

        protected async void SaveButton_Click(
            object sender,
            EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            SaveButton.Enabled = false;
            SaveButton.Text = "Zapisywanie...";

            try
            {
                var customer = new Customer
                {
                    Name = NameTextBox.Text,
                    Email = EmailTextBox.Text
                };

                await _customerService.CreateAsync(customer);

                Response.Redirect("Customers.aspx");
            }
            finally
            {
                SaveButton.Enabled = true;
                SaveButton.Text = "Dodaj klienta";
            }
        }
    }
}
