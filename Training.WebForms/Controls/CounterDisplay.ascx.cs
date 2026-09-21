using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Training.WebForms.Controls
{
    public partial class CounterDisplay : System.Web.UI.UserControl
    {
        public string Title
        {
            get
            {
                return ViewState[nameof(Title)] as string ?? "Counter";
            }
            set
            {
                ViewState[nameof(Title)] = value;
            }
        }

        public int Step
        {
            get
            {
                return ViewState[nameof(Step)] is int value ? value : 1;
            }
            set
            {
                ViewState[nameof(Step)] = value;
            }
        }

        private int CurrentCount
        {
            get
            {
                return ViewState[nameof(CurrentCount)] is int value ? value : 0;
            }
            set
            {
                ViewState[nameof(CurrentCount)] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            RenderControl();
        }

        protected void IncrementCount(object sender, EventArgs e)
        {
            CurrentCount += Step;
            RenderControl();
        }

        private void RenderControl()
        {
            TitleLiteral.Text = Title;
            CurrentCountLabel.Text = CurrentCount.ToString();
            IncrementButton.Text = $"Add {Step}";
        }
    }
}