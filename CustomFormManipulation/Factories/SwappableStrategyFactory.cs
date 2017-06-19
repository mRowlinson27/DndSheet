using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomFormManipulation.API;
using CustomFormManipulation.API.Factories;
using CustomForms.API.DTOs;
using DataManipulation.API;

namespace CustomFormManipulation.Factories
{
    public class SwappableStrategyFactory : ISwappableStrategyFactory
    {
        private readonly IPropertyApplier<IControlProperties> _propertyApplier;

        public SwappableStrategyFactory(IPropertyApplier<IControlProperties> propertyApplier )
        {
            _propertyApplier = propertyApplier;
        }

        public ISwappableStrategy Create(IControlProperties regularStyle, IControlProperties inEditStyle)
        {
            return new EditableBehaviourStrategy(_propertyApplier, regularStyle, inEditStyle);
        }
    }
}
