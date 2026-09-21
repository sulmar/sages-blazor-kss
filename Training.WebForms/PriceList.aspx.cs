using System;
using System.Web.UI;

namespace Training.WebForms
{
    public partial class PriceList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["MaxPrice"] != null)
            {
                MaxPriceTextBox.Text = Session["MaxPrice"].ToString();
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Session["MaxPrice"] = decimal.Parse(MaxPriceTextBox.Text);

            Response.Redirect("Products.aspx");
        }
    }
}
