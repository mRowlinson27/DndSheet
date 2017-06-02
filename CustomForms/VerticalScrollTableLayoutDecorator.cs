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
        public TableLayoutPanel Create()
        {
            var input = new TableLayoutPanel();
            return ApplyChanges(input);
        }

        public TableLayoutPanel Apply(TableLayoutPanel input)
        {
            return ApplyChanges(input);
        }

        private TableLayoutPanel ApplyChanges(TableLayoutPanel input)
        {
            input.HorizontalScroll.Maximum = 0;
            input.AutoScroll = false;
            input.VerticalScroll.Visible = false;
            input.AutoScroll = true;
            return input;
        }
    }
}
