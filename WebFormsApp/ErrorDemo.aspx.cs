using System;
using System.Web.UI;

namespace WebFormsApp
{
    public partial class ErrorDemo : Page
    {
        protected void ErrorButton_Click(
            object sender,
            EventArgs e)
        {
            throw new InvalidOperationException(
                "Testowy błąd aplikacji");
        }

        protected void Page_Error(
            object sender,
            EventArgs e)
        {
            var exception = Server.GetLastError();

            // Logger.Log(exception);

            Server.ClearError();

            Response.Redirect("Error.aspx");
        }
    }
}
