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
        private ITableLayoutWrapper _mainLayout;
        private ITableLayoutWrapper _centralLayoutPanel;

        public MainFormProcessor(ITableLayoutWrapper mainLayout, ICentralLayoutBuilder centralLayoutBuilder, IDataEntryFormBuilder dataEntryFormBuilder)
        {
            _centralLayoutBuilder = centralLayoutBuilder;
            _dataEntryFormBuilder = dataEntryFormBuilder;
            _mainLayout = mainLayout;
            SetUpStatPage();
        }

        public void SetUpStatPage()
        {
            _centralLayoutPanel = _centralLayoutBuilder.Create();
            _centralLayoutPanel.BackColor = Color.Aquamarine;
            _mainLayout.Controls.Add(_centralLayoutPanel.TrueControl, 0, 1);
        }

        internal void DoTheThing_Click()
        {
            _centralLayoutPanel.RowCount = _centralLayoutPanel.RowStyles.Count;
            _centralLayoutPanel.Controls.Add(_dataEntryFormBuilder.Create(null));
        }
    }
}
