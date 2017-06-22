using CustomForms.API;
using CustomForms.API.DTOs;

namespace CustomFormStructures.API
{
    public interface IDataEntryFormManager : IEditable, ITrueControl
    {
        ITrueControl GetControl(int row, int col);
    }
}
