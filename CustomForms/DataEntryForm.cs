using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CustomForms.API;

namespace CustomForms
{
    public class DataEntryForm : TableLayoutWrapper.TableLayoutWrapper, IDataEntryForm
    {
        private int _rowNum = 0;
        private int _height = 22;

        public DataEntryForm()
        {
            Dock = DockStyle.Top;
            BackColor = Color.Aqua;
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            AutoSize = true;
        }

        public bool AddRow(List<IControl> row)
        {
            if (row.Count != ColumnStyles.Count || _rowNum == RowStyles.Count)
            {
                return false;
            }

            for (var i = 0; i < ColumnStyles.Count; i++)
            {
                var data = row[i];
                AccessControls.Add(data, _rowNum, i);
            }
            _rowNum++;

            return true;
        }

        public bool AddCol()
        {
            ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            ColumnCount = ColumnStyles.Count;
            return true;
        }

        public bool AddRow()
        {
            RowStyles.Add(new RowStyle(SizeType.Absolute, 22));
            RowCount = RowStyles.Count;
            return true;
        }

        public bool AddRows(int rows)
        {
            for (var i = 0; i < rows; i++)
            {

            }
            return true;
        }

        public bool AddCols(int cols)
        {
            for (var i = 0; i < cols; i++)
            {
                
            }
            return true;
        }

        public bool InsertControl(IControl control, int row, int col)
        {
            AccessControls.Add(control, row, col);
            return true;
        }

        public IControl GetControl(int row, int col)
        {
            return null;
        }
    }
}
