using System.Collections.Generic;
using CustomForms.API;

namespace CustomFormStructures.API.Builders
{
    public interface IDataEntryFormBuilder
    {
        IDataEntryForm Build(List<List<ITrueControl>> dataListofList);
        IDataEntryForm Apply(IDataEntryForm dataEntryForm, List<List<ITrueControl>> dataListofList);
    }
}
