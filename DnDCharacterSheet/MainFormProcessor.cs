using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnDCharacterSheet
{
    class MainFormProcessor
    {
        public void DoTheThing_Click()
        {

        }

        internal void DoTheThing_Click(TableLayoutPanel mainLayout)
        {
            mainLayout.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainLayout.RowCount = mainLayout.RowStyles.Count;

            var addTable = new TableLayoutPanel();
            addTable.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            
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
