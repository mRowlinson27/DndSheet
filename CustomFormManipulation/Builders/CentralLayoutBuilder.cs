using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CustomFormManipulation.API.Builders;
using CustomFormManipulation.API.Decorators;
using CustomFormManipulation.API.DTOs;
using CustomFormManipulation.Decorators;
using CustomForms.API.Factories;
using CustomForms.API.TableLayoutWrapper;

namespace CustomFormManipulation.Builders
{
    public class CentralLayoutBuilder : ICentralLayoutBuilder
    {
        private ITableLayoutDecoratorApplier _tableLayoutDecoratorApplier;
        private List<ITableLayoutDecorator> _tableLayoutDecorators;
        private List<ITableLayoutDecoratorArguments> _tableLayoutDecoratorArguments;
        private ITableLayoutWrapperFactory _tableLayoutWrapperFactory;
        public CentralLayoutBuilder(ITableLayoutDecoratorApplier tableLayoutDecoratorApplier, ITableLayoutWrapperFactory tableLayoutWrapperFactory)
        {
            _tableLayoutDecoratorApplier = tableLayoutDecoratorApplier;
            _tableLayoutWrapperFactory = tableLayoutWrapperFactory;
            _tableLayoutDecorators = new List<ITableLayoutDecorator>
            {
                new EqualColumnsTableLayoutDecorator()
            };
            _tableLayoutDecoratorArguments = new List<ITableLayoutDecoratorArguments>
            {
                new EqualColumnsTableLayoutDecoratorArgs() {NumCols = 2}
            };
        }

        public ITableLayoutWrapper Build()
        {
            var middleLayoutPanel = _tableLayoutDecoratorApplier.Apply(_tableLayoutWrapperFactory.Create(), _tableLayoutDecorators, _tableLayoutDecoratorArguments);

            middleLayoutPanel.BackColor = Color.Beige;
            middleLayoutPanel.Dock = DockStyle.Fill;
            middleLayoutPanel.Margin = new Padding(20);

            return middleLayoutPanel;
        }
    }
}