using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomForms.API
{
    public interface IDataEntryForm : IEditable, ITrueControl
    {
        bool AddRow();
        bool AddCol();
        bool AddRows(int rows);
        bool AddCols(int cols);
        bool InsertControl(ITrueControl control, int row, int col);
        ITrueControl GetControl( int row, int col);
    }
}
