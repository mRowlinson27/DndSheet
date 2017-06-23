using CustomForms.API.DTOs;

namespace CustomFormStructures.API.Builders
{
    public interface IEditableTextBoxBuilder
    {
        IEditableTextBox Build(string data, ITextboxProperties regularStyle, ITextboxProperties inEditStyle);
    }
}
