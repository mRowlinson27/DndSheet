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

        public DataEntryForm() : this(new TableLayoutWrapper())
        {
            _tableLayoutWrapper.Dock = DockStyle.Top;
            _tableLayoutWrapper.BackColor = Color.Aqua;
            _tableLayoutWrapper.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            _tableLayoutWrapper.AutoSize = true;
            _tableLayoutWrapper.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;

        }

        public DataEntryForm(ITableLayoutWrapper tableLayoutWrapper)
        {
            _tableLayoutWrapper = tableLayoutWrapper;
            TrueControl = _tableLayoutWrapper.TrueControl;
            _insertedControls = new List<List<IControl>>();
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
            _tableLayoutWrapper.AccessRowStyles.Add(new RowStyle(SizeType.Absolute, 22));
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
    }
}
