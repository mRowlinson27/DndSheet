using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API;

namespace DnDCharacterSheet
{
    class DataEntryForm : TableLayoutPanel, IDataEntryForm
    {
        public List<Label> Labels;
        public DataEntryForm(int numLabels)
        {
            Labels = new List<Label>();
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

                var label = new Label() { Height = 13, AutoSize = true};
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
                Labels.Add(new Label() { Text = $"{i}", Width = 10, Height = 13 });
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
