using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomForms.API
{
    public interface IDataEntryForm : IControl
    {
        bool AddRow();
        bool AddCol();
        bool AddRows(int rows);
        bool AddCols(int cols);
        bool InsertControl(IControl control, int row, int col);
        IControl GetControl( int row, int col);
    }
}
