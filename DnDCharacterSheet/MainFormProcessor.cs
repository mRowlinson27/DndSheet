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
            _centraLayoutPanel.BackColor = Color.Aquamarine;
            _mainLayout.Controls.Add(_centraLayoutPanel, 0, 1);
        }

        internal void DoTheThing_Click()
        {
            //mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            _centraLayoutPanel.RowCount = _centraLayoutPanel.RowStyles.Count;
            _centraLayoutPanel.Controls.Add(new DataEntryForm(4));
        }
    }
}
