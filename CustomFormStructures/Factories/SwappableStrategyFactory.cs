using CustomFormManipulation.API;
using CustomForms.API.DTOs;
using CustomFormStructures.API;
using CustomFormStructures.API.Factories;
using DataManipulation.API;

namespace CustomFormStructures.Factories
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
