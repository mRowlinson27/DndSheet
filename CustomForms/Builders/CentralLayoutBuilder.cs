using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CustomForms.API;
using CustomForms.API.TableLayoutWrapper;
using CustomForms.Decorators;
using DnDCharacterSheet;

namespace CustomForms.Builders
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
                new VerticalScrollTableLayoutDecorator(),
                new EqualColumnsTableLayoutDecorator()
            };
            _tableLayoutDecoratorArguments = new List<ITableLayoutDecoratorArguments>
            {
                null,
                new EqualColumnsTableLayoutDecoratorArgs() {NumCols = 2}
            };
        }

        public ITableLayoutWrapper Create()
        {
            var middleLayoutPanel = _tableLayoutDecoratorApplier.Create(_tableLayoutDecorators, _tableLayoutDecoratorArguments);

            middleLayoutPanel.BackColor = Color.Beige;
            middleLayoutPanel.Dock = DockStyle.Fill;
            middleLayoutPanel.Margin = new Padding(20);

            return middleLayoutPanel;
        }
    }
}