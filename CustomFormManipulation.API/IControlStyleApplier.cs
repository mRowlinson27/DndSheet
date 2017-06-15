using CustomFormManipulation.API.DTOs;
using CustomForms.API;

namespace CustomFormManipulation.API
{
    public interface IControlStyleApplier
    {
        IControl Apply(IControl input, IControlStyle style);
    }
}
