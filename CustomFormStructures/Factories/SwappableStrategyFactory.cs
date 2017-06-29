using CustomFormManipulation.API;
using CustomForms.API.DTOs;
using CustomFormStructures.API;
using CustomFormStructures.API.Factories;
using DataManipulation.API;

namespace CustomFormStructures.Factories
{
    public class SwappableStrategyFactory : ISwappableStrategyFactory
    {
        private readonly IPropertyApplier<ITextBoxProperties> _propertyApplier;

        public SwappableStrategyFactory(IPropertyApplier<ITextBoxProperties> propertyApplier )
        {
            _propertyApplier = propertyApplier;
        }

        public ISwappableTextboxStrategy Create(ITextBoxPropertiesStyle regularStyle, ITextBoxPropertiesStyle inEditStyle)
        {
            return new EditableBehaviourTextboxStrategy(_propertyApplier, regularStyle, inEditStyle);
        }
    }
}
