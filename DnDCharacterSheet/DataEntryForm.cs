using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnDCharacterSheet
{
    class DataEntryForm : TableLayoutPanel
    {
        private List<Label> _labels;
        public DataEntryForm(int numLabels)
        {
            _labels = new List<Label>();
            Height = 40;
            Dock = DockStyle.Top;
            BackColor = Color.Aqua;
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            
            GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            ColumnCount = ColumnStyles.Count;
            RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            RowCount = RowStyles.Count;

            for (int i = 0; i < numLabels; i++)
            {
                ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                ColumnCount = ColumnStyles.Count;

                _labels.Add(new Label() { Text = $"{i}", Width = 10, Height = 13 });
                _labels.ElementAt(i).BackColor = Color.Red;
                if (i == 1)
                    _labels.ElementAt(i).BackColor = Color.Green;
                if (i == 2)
                    _labels.ElementAt(i).BackColor = Color.Blue;
                if (i == 3)
                    _labels.ElementAt(i).BackColor = Color.Violet;
                Controls.Add(_labels.ElementAt(i));
            }

            GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            RowCount = RowStyles.Count;

            for (int i = 0; i < numLabels; i++)
            {
                _labels.Add(new Label() { Text = $"{i}", Width = 10, Height = 13 });
                _labels.ElementAt(i + 3).BackColor = Color.Violet;
                if (i == 1)
                    _labels.ElementAt(i + 3).BackColor = Color.Blue;
                if (i == 2)
                    _labels.ElementAt(i + 3).BackColor = Color.Green;
                if (i == 3)
                    _labels.ElementAt(i + 3).BackColor = Color.Red;
                Controls.Add(_labels.ElementAt(i + 3));
            }
        }
    }
}
