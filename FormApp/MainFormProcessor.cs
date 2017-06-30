using System.Drawing;
using System.Windows.Forms;
using CustomFormManipulation.API;
using CustomForms.API.DTOs;
using CustomForms.API.TableLayoutWrapper;
using CustomForms.DTOs;
using CustomFormStructures.API;
using CustomFormStructures.API.Builders;
using DataManipulation.API;

namespace FormApp
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
            var centralLayoutStyle = new ControlPropertiesStyle
            {
                BackColor = Color.Aquamarine,
                Dock = DockStyle.Fill,
                Margin = new Padding(20)
            };

            _centralLayoutPanel = _centralLayoutBuilder.Build(centralLayoutStyle);
            _centralLayoutPanel = _verticalScrollStrategy.ExecuteOn(_centralLayoutPanel);

            _mainLayout.AccessControls.Add(_centralLayoutPanel, 2, 1);
            _centralLayoutPanel.AccessControls.Add(_dataEntryFormManager);
        }

        internal void DoTheThing_Click()
        {
//            if (_dataEntryFormManager.EditableStatus == EditableStatus.Regular)
//            {
//                _dataEntryFormManager.EditableStatus = EditableStatus.InEdit;
//            }
//            else
//            {
//                _dataEntryFormManager.EditableStatus = EditableStatus.Regular;
//            }
            var data = _dataEntryFormManager.GetControl(2, 2);
            //_dataEntryFormManager.GetControl(2, 2).TrueControl.Visible = false;
        }
    }
}
