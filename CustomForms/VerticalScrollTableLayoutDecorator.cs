using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API;

namespace CustomForms
{
    class VerticalScrollTableLayoutDecorator : ITableLayoutDecorator
    {
        public ITableLayoutWrapper Create()
        {
            var input = new TableLayoutWrapper();
            return ApplyChanges(input);
        }

        public ITableLayoutWrapper Apply(ITableLayoutWrapper input)
        {
            return ApplyChanges(input);
        }

        private ITableLayoutWrapper ApplyChanges(ITableLayoutWrapper input)
        {
            input.AutoScroll = false;
            input.HorizontalScroll.Maximum = 0;
            input.VerticalScroll.Visible = false;
            input.HorizontalScroll.Visible = false;
            input.AutoScroll = true;
            return input;
        }
    }
}
