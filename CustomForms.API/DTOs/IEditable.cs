namespace CustomForms.API.DTOs
{
    public interface IEditable : ITrueControl
    {
        bool Editable { get; set; }
    }
}
