using CustomForms.API.DTOs;

namespace CustomFormStructures.API
{
    public interface ISwappableStrategy
    {
        IControl SwapTo(IControl control, bool regularMode);
    }
}
