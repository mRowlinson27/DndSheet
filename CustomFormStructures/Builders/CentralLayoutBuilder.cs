using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CustomForms.API.DTOs;
using CustomForms.API.Factories;
using CustomForms.API.TableLayoutWrapper;
using CustomFormStructures.API.Builders;
using CustomFormStructures.API.Decorators;
using DataManipulation.API;

namespace CustomFormStructures.Builders
{
    public class CentralLayoutBuilder : ICentralLayoutBuilder
    {
        private ITableLayoutDecoratorApplier _tableLayoutDecoratorApplier;
        private List<ITableLayoutDecorator> _tableLayoutDecorators;
        private ITableLayoutWrapperFactory _tableLayoutWrapperFactory;
        private readonly IPropertyApplier<IControlProperties> _propertyApplier;

        public CentralLayoutBuilder(ITableLayoutDecoratorApplier tableLayoutDecoratorApplier, List<ITableLayoutDecorator> tableLayoutDecorators, ITableLayoutWrapperFactory tableLayoutWrapperFactory, IPropertyApplier<IControlProperties> propertyApplier)
        {
            _tableLayoutDecoratorApplier = tableLayoutDecoratorApplier;
            _tableLayoutWrapperFactory = tableLayoutWrapperFactory;
            _propertyApplier = propertyApplier;
            _tableLayoutDecorators = tableLayoutDecorators;
        }

        public ITableLayoutWrapper Build(IControlPropertiesStyle tablePropertiesStyle = null)
        {
            var middleLayoutPanel = _tableLayoutDecoratorApplier.Apply(_tableLayoutWrapperFactory.Create(), _tableLayoutDecorators);

            if (tablePropertiesStyle != null)
            {
                _propertyApplier.Apply(middleLayoutPanel, tablePropertiesStyle);
            }
            return middleLayoutPanel;
        }
    }
}