using CustomForms.API.DTOs;

namespace CustomFormStructures.API.Factories
{
    public interface ISwappableStrategyFactory
    {
        ISwappableTextboxStrategy Create(ITextboxProperties regularStyle, ITextboxProperties inEditStyle);
    }
}
