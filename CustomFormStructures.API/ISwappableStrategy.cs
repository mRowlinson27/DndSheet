using CustomForms.API;
using CustomForms.API.DTOs;

namespace CustomFormStructures.API
{
    public interface ISwappableTextboxStrategy
    {
        ITextBoxWrapper SwapTo(ITextBoxWrapper control, bool regularMode);
    }
}
