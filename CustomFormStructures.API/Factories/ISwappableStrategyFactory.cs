using CustomForms.API.DTOs;

namespace CustomFormStructures.API.Factories
{
    public interface ISwappableStrategyFactory
    {
        ISwappableTextboxStrategy Create(ITextBoxPropertiesStyle regularStyle, ITextBoxPropertiesStyle inEditStyle);
    }
}
