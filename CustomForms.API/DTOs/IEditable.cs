namespace CustomForms.API.DTOs
{
    public interface IEditable : ITrueControl
    {
        EditableStatus EditableStatus { get; set; }
    }

    public enum EditableStatus
    {
        Regular,
        InEdit
    }
}
