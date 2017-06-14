using CustomForms.API;

namespace CustomFormStructures.API
{
    public interface IEditable : ITrueControl
    {
        bool Editable { get; set; }
    }
}
