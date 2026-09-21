using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Training.WebForms.Controls
{
    public partial class SearchPanel : System.Web.UI.UserControl
    {
        public string Value
        {
            get => SearchTextBox.Text;
            set => SearchTextBox.Text = value;
        }

        public event EventHandler<ValueChangedEventArgs> ValueChanged;

        protected void Search(object sender, EventArgs e)
        {
            var value = SearchTextBox.Text.Trim();

            ValueChanged?.Invoke(this, new ValueChangedEventArgs(value));
        }

        public sealed class ValueChangedEventArgs : EventArgs
        {
            public ValueChangedEventArgs(string value)
            {
                Value = value;
            }

            public string Value { get; }
        }
    }
}