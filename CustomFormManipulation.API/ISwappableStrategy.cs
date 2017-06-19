using CustomFormManipulation.API.DTOs;
using CustomForms.API;
using CustomForms.API.DTOs;

namespace CustomFormManipulation.API
{
    public interface ISwappableStrategy
    {
        IControl SwapTo(IControl control, bool regularMode);
    }
}
