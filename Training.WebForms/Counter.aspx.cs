using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Training.WebForms
{
    public partial class Counter : System.Web.UI.Page
    {
        private int currentCount
        {
            get
            {
                return ViewState[nameof(currentCount)] is int value ? value : 0;
            }
            set
            {
                ViewState[nameof(currentCount)] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentCountLabel.Text = currentCount.ToString();
        }

        protected void IncrementCount(object sender, EventArgs e)
        {
            currentCount++;
            CurrentCountLabel.Text = currentCount.ToString();
        }
    }
}