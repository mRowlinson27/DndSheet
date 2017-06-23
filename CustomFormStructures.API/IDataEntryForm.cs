using CustomForms.API;
using CustomForms.API.DTOs;

namespace CustomFormStructures.API
{
    public interface IDataEntryForm : IEditable
    {
        bool AddRow();
        bool AddCol();
        bool AddRows(int rows);
        bool AddCols(int cols);
        bool InsertControl(ITrueControl control, int row, int col);
        ITrueControl GetControl( int row, int col);
    }
}
