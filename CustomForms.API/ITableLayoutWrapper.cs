using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomForms.API
{
    public interface ITableLayoutWrapper : IControl
    {
        Control TrueControl { get; }
        ITableLayoutControlCollectionWrapper Controls { get; }

        TableLayoutPanelCellBorderStyle CellBorderStyle { get; set; }

        TableLayoutPanelGrowStyle GrowStyle { get; set; }

        int Height { get; set; }
        int Width { get; set; }

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
