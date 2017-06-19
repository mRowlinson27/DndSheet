using CustomForms.API.DTOs;

namespace CustomFormStructures.API
{
    public interface IEditableTextBox : IEditable
    {
        string Text { get; set; }
    }
}
