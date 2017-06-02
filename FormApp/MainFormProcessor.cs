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
    public class MainFormProcessor
    {
        private int Count = 0;
        private ICentralLayoutBuilder _centralLayoutBuilder;
        private IDataEntryFormBuilder _dataEntryFormBuilder;
        private TableLayoutPanel _mainLayout;
        private TableLayoutPanel _centraLayoutPanel;

        public MainFormProcessor(TableLayoutPanel mainLayout, ICentralLayoutBuilder centralLayoutBuilder, IDataEntryFormBuilder dataEntryFormBuilder)
        {
            _centralLayoutBuilder = centralLayoutBuilder;
            _dataEntryFormBuilder = dataEntryFormBuilder;
            _mainLayout = mainLayout;
            SetUpStatPage();
        }

        public void SetUpStatPage()
        {
            _centraLayoutPanel = _centralLayoutBuilder.Create();
            _centraLayoutPanel.BackColor = Color.Aquamarine;
            _mainLayout.Controls.Add(_centraLayoutPanel, 0, 1);
        }

        internal void DoTheThing_Click()
        {
            //mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            _centraLayoutPanel.RowCount = _centraLayoutPanel.RowStyles.Count;
            _centraLayoutPanel.Controls.Add(_dataEntryFormBuilder.Create());
        }
    }
}
