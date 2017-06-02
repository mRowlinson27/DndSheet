using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomForms.API
{
    public interface ITableLayoutWrapper
    {
        Control TrueControl { get; }
        TableLayoutControlCollection Controls { get; }

        TableLayoutRowStyleCollection RowStyles { get; }
        int RowCount { get; set; }
        TableLayoutColumnStyleCollection ColumnStyles { get; }
        int ColumnCount { get; set; }

        Padding Margin { get; set; }

        DockStyle Dock { get; set; }

        Color BackColor { get; set; }

        bool AutoScroll { get; set; }

        HScrollProperties HorizontalScroll { get; }
        VScrollProperties VerticalScroll { get; }
    }
}
