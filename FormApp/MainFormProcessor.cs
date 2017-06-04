using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API;
using CustomForms.API.Builders;
using CustomForms.API.TableLayoutWrapper;

namespace DnDCharacterSheet
{
    public class MainFormProcessor
    {
        private ICentralLayoutBuilder _centralLayoutBuilder;
        private ITableLayoutBuilder _tableLayoutBuilder;
        private ITableLayoutWrapper _mainLayout;
        private ITableLayoutWrapper _centralLayoutPanel;

        public MainFormProcessor(ITableLayoutWrapper mainLayout, ICentralLayoutBuilder centralLayoutBuilder, ITableLayoutBuilder tableLayoutBuilder)
        {
            _centralLayoutBuilder = centralLayoutBuilder;
            _tableLayoutBuilder = tableLayoutBuilder;
            _mainLayout = mainLayout;
        }

        public void SetUpStatPage()
        {
            _centralLayoutPanel = _centralLayoutBuilder.Create();
            _centralLayoutPanel.BackColor = Color.Aquamarine;
            _mainLayout.AccessControls.Add(_centralLayoutPanel, 2, 1);
        }

        internal void DoTheThing_Click()
        {
            _centralLayoutPanel.RowCount = _centralLayoutPanel.AccessRowStyles.Count;
            List<List<string>> data = new List<List<string>>
            {
                new List<string>
                {
                    "Acrobatics", "Dex"
                },
                new List<string>
                {
                    "Appraise", "b", "c"
                }
            };
            _centralLayoutPanel.AccessControls.Add(_tableLayoutBuilder.Create(data));
        }
    }
}
