using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms;
using CustomForms.API;
using CustomForms.API.Builders;
using CustomForms.API.TableLayoutWrapper;
using DataManipulation.API;

namespace DnDCharacterSheet
{
    public class MainFormProcessor
    {
        private ICentralLayoutBuilder _centralLayoutBuilder;
        private IDataEntryFormManager _dataEntryFormManager;
        private ITableLayoutWrapper _mainLayout;
        private ITableLayoutWrapper _centralLayoutPanel;
        private IVerticalScrollStrategy _verticalScrollStrategy;

        public MainFormProcessor(ITableLayoutWrapper mainLayout, ICentralLayoutBuilder centralLayoutBuilder, IDataEntryFormManager dataEntryFormManager, IVerticalScrollStrategy verticalScrollStrategy)
        {
            _centralLayoutBuilder = centralLayoutBuilder;
            _dataEntryFormManager = dataEntryFormManager;
            _mainLayout = mainLayout;
            _verticalScrollStrategy = verticalScrollStrategy;
        }

        public void SetUpStatPage()
        {
            _centralLayoutPanel = _centralLayoutBuilder.Build();
            _centralLayoutPanel = _verticalScrollStrategy.ExecuteOn(_centralLayoutPanel);
            _centralLayoutPanel.BackColor = Color.Aquamarine;
            _mainLayout.AccessControls.Add(_centralLayoutPanel, 2, 1);
            _centralLayoutPanel.AccessControls.Add(_dataEntryFormManager);
        }

        internal void DoTheThing_Click()
        {
            _dataEntryFormManager.Editable = !_dataEntryFormManager.Editable;
            //_dataEntryFormManager.GetControl(2, 2).TrueControl.Visible = false;
            _centralLayoutPanel.BackColor = Color.Red;
        }
    }
}
