using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CustomForms.API.Factories;
using CustomForms.API.TableLayoutWrapper;
using CustomFormStructures.API.Builders;
using CustomFormStructures.API.Decorators;

namespace CustomFormStructures.Builders
{
    public class CentralLayoutBuilder : ICentralLayoutBuilder
    {
        private ITableLayoutDecoratorApplier _tableLayoutDecoratorApplier;
        private List<ITableLayoutDecorator> _tableLayoutDecorators;
        private ITableLayoutWrapperFactory _tableLayoutWrapperFactory;
        public CentralLayoutBuilder(ITableLayoutDecoratorApplier tableLayoutDecoratorApplier, List<ITableLayoutDecorator> tableLayoutDecorators, ITableLayoutWrapperFactory tableLayoutWrapperFactory)
        {
            _tableLayoutDecoratorApplier = tableLayoutDecoratorApplier;
            _tableLayoutWrapperFactory = tableLayoutWrapperFactory;
            _tableLayoutDecorators = tableLayoutDecorators;
        }

        public ITableLayoutWrapper Build()
        {
            var middleLayoutPanel = _tableLayoutDecoratorApplier.Apply(_tableLayoutWrapperFactory.Create(), _tableLayoutDecorators);

            middleLayoutPanel.BackColor = Color.Beige;
            middleLayoutPanel.Dock = DockStyle.Fill;
            middleLayoutPanel.Margin = new Padding(20);

            return middleLayoutPanel;
        }
    }
}