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
        private ICentralLayoutPanelFactory _centralLayoutPanelFactory;
        private TableLayoutPanel _mainLayout;
        private TableLayoutPanel _centraLayoutPanel;

        public MainFormProcessor(TableLayoutPanel mainLayout, ICentralLayoutPanelFactory centralLayoutPanelFactory)
        {
            _centralLayoutPanelFactory = centralLayoutPanelFactory;
            _mainLayout = mainLayout;
            SetUpStatPage();
        }

        public void SetUpStatPage()
        {
            _centraLayoutPanel = _centralLayoutPanelFactory.Create();
            _mainLayout.Controls.Add(_centraLayoutPanel, 0, 1);
        }

        internal void DoTheThing_Click()
        {
            //mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            _centraLayoutPanel.RowCount = _centraLayoutPanel.RowStyles.Count;

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

            _centraLayoutPanel.Controls.Add(addTable);
        }
    }
}
