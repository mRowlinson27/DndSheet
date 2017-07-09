using CustomForms.API.DTOs;

namespace CustomFormManipulation.API.DTOs
{
    public interface IControlStyle
    {
        IControlProperties ControlProperties { get; }
        IControlEvents ControlEvents { get; }
    }
}
