using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API;

namespace DataManipulation.API
{
    public interface IDataEntryFormManager : IEditable, ITrueControl
    {
        ITrueControl GetControl(int row, int col);
    }
}
