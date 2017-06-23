using System;
using System.Drawing;
using System.Windows.Forms;
using CustomForms.API.DTOs;

namespace CustomForms.API.TableLayoutWrapper
{
    public interface ITableLayoutWrapper : IControl
    {
        Point PointToClient(Point p);
        event ScrollEventHandler Scroll;
        
        ITableLayoutControlCollectionWrapper AccessControls { get; }

        TableLayoutPanelCellBorderStyle CellBorderStyle { get; set; }

        TableLayoutPanelGrowStyle GrowStyle { get; set; }
        int[] GetRowHeights();
        int[] GetColumnWidths();

        ITableLayoutRowStyleCollectionWrapper AccessRowStyles { get; }
        int RowCount { get; set; }
        ITableLayoutColumnStyleCollectionWrapper AccessColumnStyles { get; }
        int ColumnCount { get; set; }
        bool AutoScroll { get; set; }
        IHScrollPropertiesWrapper AccessHorizontalScroll { get; }
        IVScrollPropertiesWrapper AccessVerticalScroll { get; }
    }
}
