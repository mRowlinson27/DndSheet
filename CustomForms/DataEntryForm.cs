using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms;
using CustomForms.API;
using CustomForms.TableLayoutWrapper;

namespace DnDCharacterSheet
{
    class DataEntryForm : TableLayoutWrapper, IDataEntryForm
    {
        public List<LabelWrapper> Labels;
        public int Rows { get; set; }
        public int Cols { get; set; }
        private int _rowNum = 0;
        private int _height;
        public DataEntryForm(int rows, int cols, int height)
        {
            Labels = new List<LabelWrapper>();
            Rows = rows;
            Cols = cols;
            _height = height;

            Height = Rows* (_height + 2) + 2;
            Dock = DockStyle.Top;
            BackColor = Color.Aqua;
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            for (int r = 0; r < rows; r++)
            {
                RowStyles.Add(new RowStyle(SizeType.Absolute,_height));
            }
            RowCount = RowStyles.Count;
            for (int c = 0; c < cols; c++)
            {
                ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            }
            ColumnCount = ColumnStyles.Count;
        }

        public bool AddRow(List<object> row)
        {
            if (row.Count != Cols || _rowNum == Rows)
            {
                return false;
            }

            for (var i = 0; i < Cols; i++)
            {
                var data = row[i];
                var label = new LabelWrapper() { Height = _height  };
                label.Text = (string) data;
                Controls.Add(label, i, _rowNum);
            }
            _rowNum++;

            return true;
            var numLabels = 3;
            GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            ColumnCount = ColumnStyles.Count;
            RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            RowCount = RowStyles.Count;

            for (int i = 0; i < numLabels; i++)
            {
                ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                ColumnCount = ColumnStyles.Count;

                var label = new LabelWrapper() { Height = 13, AutoSize = true };
                label.Text = $"{i}";
                for (int j = 0; j <= i; j++)
                    label.Text += $" - {j}";
                Labels.Add(label);
                Labels.ElementAt(i).BackColor = Color.Red;
                if (i == 1)
                    Labels.ElementAt(i).BackColor = Color.Green;
                if (i == 2)
                    Labels.ElementAt(i).BackColor = Color.Blue;
                if (i == 3)
                    Labels.ElementAt(i).BackColor = Color.Violet;
                Controls.Add(Labels.ElementAt(i));
            }

            GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            RowCount = RowStyles.Count;

            for (int i = 0; i < numLabels; i++)
            {
                Labels.Add(new LabelWrapper() { Text = $"{i}", Width = 10, Height = 13 });
                Labels.ElementAt(i + 3).BackColor = Color.Violet;
                if (i == 1)
                    Labels.ElementAt(i + 3).BackColor = Color.Blue;
                if (i == 2)
                    Labels.ElementAt(i + 3).BackColor = Color.Green;
                if (i == 3)
                    Labels.ElementAt(i + 3).BackColor = Color.Red;
                Controls.Add(Labels.ElementAt(i + 3));
            }
        }
    }
}
