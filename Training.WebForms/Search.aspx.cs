using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Training.WebForms.Controls.SearchPanel;

namespace Training.WebForms
{
    public partial class Search : System.Web.UI.Page
    {
        protected void SearchValueChanged(object sender, ValueChangedEventArgs e)
        {
            SearchValueLabel.Text = e.Value;
        }        
    }
}