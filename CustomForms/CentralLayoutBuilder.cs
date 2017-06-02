using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CustomForms;
using CustomForms.API;

namespace DnDCharacterSheet
{
    public class CentralLayoutBuilder : ICentralLayoutBuilder
    {
        private ITableLayoutDecoratorApplier _tableLayoutDecoratorApplier;
        private List<ITableLayoutDecorator> _tableLayoutDecorators; 
        public CentralLayoutBuilder(ITableLayoutDecoratorApplier tableLayoutDecoratorApplier)
        {
            _tableLayoutDecoratorApplier = tableLayoutDecoratorApplier;
            _tableLayoutDecorators = new List<ITableLayoutDecorator>
            {
                new VerticalScrollTableLayoutDecorator()
            };
        }

        public TableLayoutPanel Create()
        {
            var middleLayoutPanel = _tableLayoutDecoratorApplier.Create(_tableLayoutDecorators);

            middleLayoutPanel.BackColor = Color.Beige;
            middleLayoutPanel.Dock = DockStyle.Fill;
            middleLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            middleLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            middleLayoutPanel.ColumnCount = middleLayoutPanel.ColumnStyles.Count;
            middleLayoutPanel.Margin = new Padding(20);
            return middleLayoutPanel;
        }
    }
}