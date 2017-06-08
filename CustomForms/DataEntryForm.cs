using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using CustomForms.API;
using CustomForms.API.TableLayoutWrapper;
using CustomForms.TableLayoutWrapperFields;

namespace CustomForms
{
    public class DataEntryForm : IDataEntryForm
    {
        private int _rowNum = 0;
        private int _colNum = 0;
        private int _height = 22;
        private ITableLayoutWrapper _tableLayoutWrapper;
        private List<List<IControl>> _insertedControls; 

        public Control TrueControl { get; }
        public event EventHandler Click;

        private bool _inEdit = false;
        public bool Editable
        {
            get { return _inEdit; }
            set
            {
                if (_inEdit && !value)
                {
                    LeaveEditMode();
                }
                else if (!_inEdit && value)
                {
                    EnterEditMode();
                }
                _inEdit = value;
            }
        }

        public DataEntryForm() : this(new TableLayoutWrapper())
        {
            _tableLayoutWrapper.Dock = DockStyle.Top;
            _tableLayoutWrapper.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            _tableLayoutWrapper.AutoSize = true;
            _tableLayoutWrapper.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        }

        public DataEntryForm(ITableLayoutWrapper tableLayoutWrapper)
        {
            _tableLayoutWrapper = tableLayoutWrapper;
            TrueControl = _tableLayoutWrapper.TrueControl;
            _insertedControls = new List<List<IControl>>();
            _tableLayoutWrapper.Click += _tableLayoutWrapper_Click;
        }

        private void _tableLayoutWrapper_Click(object sender, EventArgs e)
        {
            var point = _tableLayoutWrapper.PointToClient(Cursor.Position);
            if (point.X > _tableLayoutWrapper.Width || point.Y > _tableLayoutWrapper.Height)
                return;
            var w = _tableLayoutWrapper.Width;
            var h = _tableLayoutWrapper.Height;
            int i;
            var widths = _tableLayoutWrapper.GetColumnWidths();
            for (i = widths.Length - 1; i >= 0 && point.X < w; i--)
                w -= widths[i];
            var col = i + 1;
            var heights = _tableLayoutWrapper.GetRowHeights();
            for (i = heights.Length - 1; i >= 0 && point.Y < h; i--)
                h -= heights[i];
            var row = i + 1;

            MessageBox.Show($"row: {row+1}. col: {col+1}");
        }

        private void _tableLayoutWrapperChild_Click(object sender, EventArgs e)
        {
            _tableLayoutWrapper_Click(sender, e);
        }

        public bool AddCol()
        {
            _tableLayoutWrapper.AccessColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            _tableLayoutWrapper.ColumnCount = _tableLayoutWrapper.AccessColumnStyles.Count;

            foreach (var row in _insertedControls)
            {
                row.Add(null);
            }

            _colNum++;
            return true;
        }

        public bool AddRow()
        {
            _tableLayoutWrapper.AccessRowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            _tableLayoutWrapper.RowCount = _tableLayoutWrapper.AccessRowStyles.Count;
            _insertedControls.Add(new List<IControl>());
            _rowNum++;
            return true;
        }

        public bool AddRows(int rows)
        {
            for (var i = 0; i < rows; i++)
            {
                AddRow();
            }
            return true;
        }

        public bool AddCols(int cols)
        {
            for (var i = 0; i < cols; i++)
            {
                AddCol();
            }
            return true;
        }

        public bool InsertControl(IControl control, int row, int col)
        {
            if (row > _rowNum || col > _colNum)
            {
                throw new IndexOutOfRangeException();
            }
            control.Click += _tableLayoutWrapperChild_Click;
            _tableLayoutWrapper.AccessControls.Add(control, row, col);
            _insertedControls[row-1][col-1] = control;
            return true;
        }

        public IControl GetControl(int row, int col)
        {
            if (row > _rowNum || col > _colNum)
            {
                throw new IndexOutOfRangeException();
            }
            return _insertedControls[row-1][col-1];
        }

        private void EnterEditMode()
        {
            foreach (var listOfControls in _insertedControls)
            {
                foreach (var control in listOfControls)
                {
                    var editableControl = control as IEditable;
                    if (editableControl != null)
                    {
                        editableControl.Editable = true;
                    }
                }
            }
        }

        private void LeaveEditMode()
        {
            foreach (var listOfControls in _insertedControls)
            {
                foreach (var control in listOfControls)
                {
                    var editableControl = control as IEditable;
                    if (editableControl != null)
                    {
                        editableControl.Editable = false;
                    }
                }
            }
        }
    }
}
