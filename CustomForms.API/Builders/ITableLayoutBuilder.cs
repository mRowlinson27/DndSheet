using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomForms.API.Builders
{
    public interface ITableLayoutBuilder
    {
        IDataEntryForm Build(List<List<ITrueControl>> dataListofList);
        IDataEntryForm Apply(IDataEntryForm dataEntryForm, List<List<ITrueControl>> dataListofList);
    }
}
