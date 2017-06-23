using CustomFormManipulation.API;
using CustomForms.API.DTOs;
using CustomFormStructures.API;
using CustomFormStructures.API.Factories;
using DataManipulation.API;

namespace CustomFormStructures.Factories
{
    public class SwappableStrategyFactory : ISwappableStrategyFactory
    {
        private readonly IPropertyApplier<ITextboxProperties> _propertyApplier;

        public SwappableStrategyFactory(IPropertyApplier<ITextboxProperties> propertyApplier )
        {
            _propertyApplier = propertyApplier;
        }

        public ISwappableTextboxStrategy Create(ITextboxProperties regularStyle, ITextboxProperties inEditStyle)
        {
            return new EditableBehaviourTextboxStrategy(_propertyApplier, regularStyle, inEditStyle);
        }
    }
}
