using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CustomForms;
using CustomForms.API;
using CustomForms.API.TableLayoutWrapper;
using CustomForms.Decorators;

namespace DnDCharacterSheet
{
    public class CentralLayoutBuilder : ICentralLayoutBuilder
    {
        private ITableLayoutDecoratorApplier _tableLayoutDecoratorApplier;
        private List<ITableLayoutDecorator> _tableLayoutDecorators;
        private List<ITableLayoutDecoratorArguments> _tableLayoutDecoratorArguments;
        public CentralLayoutBuilder(ITableLayoutDecoratorApplier tableLayoutDecoratorApplier)
        {
            _tableLayoutDecoratorApplier = tableLayoutDecoratorApplier;
            _tableLayoutDecorators = new List<ITableLayoutDecorator>
            {
                new VerticalScrollTableLayoutDecorator()
            };
            _tableLayoutDecoratorArguments = new List<ITableLayoutDecoratorArguments>
            {
                null
            };
        }

        public ITableLayoutWrapper Create()
        {
            var middleLayoutPanel = _tableLayoutDecoratorApplier.Create(_tableLayoutDecorators, _tableLayoutDecoratorArguments);

            middleLayoutPanel.BackColor = Color.Beige;
            middleLayoutPanel.Dock = DockStyle.Fill;
            middleLayoutPanel.AccessColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            middleLayoutPanel.AccessColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            middleLayoutPanel.ColumnCount = middleLayoutPanel.AccessColumnStyles.Count;
            middleLayoutPanel.Margin = new Padding(20);
            return middleLayoutPanel;
        }
    }
}