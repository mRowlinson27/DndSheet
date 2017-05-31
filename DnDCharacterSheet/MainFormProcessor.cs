using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnDCharacterSheet
{
    class MainFormProcessor
    {
        private int Count = 0;

        internal void DoTheThing_Click(TableLayoutPanel mainLayout)
        {
            //mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainLayout.RowCount = mainLayout.RowStyles.Count;

            var addTable = new TableLayoutPanel();
            addTable.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            addTable.Dock = DockStyle.Fill;
            addTable.BackColor = Color.Brown;
            
            var label = new Label();
            label.Text = "test";
            var label2 = new Label();
            label2.Text = "test2";
            var label3 = new Label();
            label3.Text = "test3";

            addTable.Controls.Add(label);
            addTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            addTable.RowCount = addTable.RowStyles.Count;
            addTable.Controls.Add(label2);
            addTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            addTable.RowCount = addTable.RowStyles.Count;
            addTable.Controls.Add(label3);

            mainLayout.Controls.Add(addTable);
        }
    }
}
