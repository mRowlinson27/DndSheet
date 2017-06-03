using System.Drawing;
using System.Windows.Forms;

namespace CustomForms.API.TableLayoutWrapper
{
    public interface ITableLayoutWrapper : IControl
    {
        ITableLayoutControlCollectionWrapper AccessControls { get; }

        TableLayoutPanelCellBorderStyle CellBorderStyle { get; set; }

        TableLayoutPanelGrowStyle GrowStyle { get; set; }

        int Height { get; set; }
        int Width { get; set; }

        ITableLayoutRowStyleCollectionWrapper AccessRowStyles { get; }
        int RowCount { get; set; }
        ITableLayoutColumnStyleCollectionWrapper AccessColumnStyles { get; }
        int ColumnCount { get; set; }

        Padding Margin { get; set; }

        DockStyle Dock { get; set; }

        Color BackColor { get; set; }

        bool AutoScroll { get; set; }

        IHScrollPropertiesWrapper AccessHorizontalScroll { get; }
        IVScrollPropertiesWrapper AccessVerticalScroll { get; }
    }
}
