using CustomForms.API.DTOs;

namespace CustomFormStructures.API.Factories
{
    public interface ISwappableStrategyFactory
    {
        ISwappableStrategy Create(IControlProperties regularStyle, IControlProperties inEditStyle);
    }
}
