using CustomFormManipulation.API.DTOs;
using CustomForms.API;
using CustomForms.API.DTOs;

namespace CustomFormManipulation.API
{
    public interface IControlStyleApplier
    {
        IControl Apply(IControl input, IControlStyle style);
    }
}
