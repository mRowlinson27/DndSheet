using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API;

namespace CustomForms
{
    public class TableLayoutWrapper : ITableLayoutWrapper
    {
        private TableLayoutPanel _trueControl;
        public TableLayoutWrapper()
        {
            _trueControl = new TableLayoutPanel();
        }

        public TableLayoutWrapper(TableLayoutPanel input)
        {
            _trueControl = input;
        }

        public Control TrueControl => _trueControl;

        public TableLayoutControlCollection Controls => _trueControl.Controls;

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
