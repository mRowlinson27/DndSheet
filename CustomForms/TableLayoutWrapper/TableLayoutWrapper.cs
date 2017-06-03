using System.Drawing;
using System.Windows.Forms;
using CustomForms.API;

namespace CustomForms.TableLayoutWrapper
{
    public class TableLayoutWrapper : ITableLayoutWrapper
    {
        private TableLayoutPanel _trueControl;
        private TableLayoutControlCollectionWrapper _layoutControlCollectionWrapper;
        public TableLayoutWrapper()
        {
            _trueControl = new TableLayoutPanel();
            Setup();
        }

        public TableLayoutWrapper(TableLayoutPanel input)
        {
            _trueControl = input;
            Setup();
        }

        private void Setup()
        {
            _layoutControlCollectionWrapper = new TableLayoutControlCollectionWrapper(_trueControl.Controls);
        }

        public Control TrueControl => _trueControl;

        public ITableLayoutControlCollectionWrapper Controls => _layoutControlCollectionWrapper;

        public TableLayoutPanelCellBorderStyle CellBorderStyle
        {
            get => _trueControl.CellBorderStyle;
            set => _trueControl.CellBorderStyle = value;
        }

        public TableLayoutPanelGrowStyle GrowStyle
        {
            get => _trueControl.GrowStyle;
            set => _trueControl.GrowStyle = value;
        }

        public int Height
        {
            get => _trueControl.Height;
            set => _trueControl.Height = value;
        }

        public int Width
        {
            get => _trueControl.Width;
            set => _trueControl.Width = value;
        }

        public TableLayoutRowStyleCollection RowStyles => _trueControl.RowStyles;
        public int RowCount
        {
            get => _trueControl.RowCount;
            set => _trueControl.RowCount = value;
        }
        public TableLayoutColumnStyleCollection ColumnStyles => _trueControl.ColumnStyles;
        public int ColumnCount
        {
            get => _trueControl.ColumnCount;
            set => _trueControl.ColumnCount = value;
        }

        public Padding Margin
        {
            get => _trueControl.Margin;
            set => _trueControl.Margin = value;
        }

        public DockStyle Dock
        {
            get => _trueControl.Dock;
            set => _trueControl.Dock = value;
        }

        public Color BackColor
        {
            get => _trueControl.BackColor;
            set => _trueControl.BackColor = value;
        }

        public bool AutoScroll
        {
            get => _trueControl.AutoScroll;
            set => _trueControl.AutoScroll = value;
        }

        public HScrollProperties HorizontalScroll => _trueControl.HorizontalScroll;
        public VScrollProperties VerticalScroll => _trueControl.VerticalScroll;
    }
}
