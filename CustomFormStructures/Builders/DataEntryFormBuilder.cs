using System.Collections.Generic;
using CustomForms;
using CustomForms.API;
using CustomForms.API.Factories;
using CustomFormStructures.API;
using CustomFormStructures.API.Builders;

namespace CustomFormStructures.Builders
{
    public class DataEntryFormBuilder : IDataEntryFormBuilder
    {
        private ITableLayoutWrapperFactory _tableLayoutWrapperFactory;

        public DataEntryFormBuilder(ITableLayoutWrapperFactory tableLayoutWrapperFactory)
        {
            _tableLayoutWrapperFactory = tableLayoutWrapperFactory;
        }

        public IDataEntryForm Build(List<List<ITrueControl>> dataListofList)
        {
            var dataEntryForm = new DataEntryForm(_tableLayoutWrapperFactory.Create());
            return Build(dataEntryForm, dataListofList);
        }

        public IDataEntryForm Apply(IDataEntryForm dataEntryForm, List<List<ITrueControl>> dataListofList)
        {
            return Build(dataEntryForm, dataListofList);
        }

        private IDataEntryForm Build(IDataEntryForm dataEntryForm, List<List<ITrueControl>> dataListofList)
        {
            int maxCols = 0;
            foreach (var datalist in dataListofList)
            {
                if (datalist.Count > maxCols)
                {
                    maxCols = datalist.Count;
                }
            }
            dataEntryForm.AddRows(dataListofList.Count);
            dataEntryForm.AddCols(maxCols);

            for (var r = 0; r < dataListofList.Count; r++)
            {
                for (var c = 0; c < dataListofList[r].Count; c++)
                {
                    dataEntryForm.InsertControl(dataListofList[r][c], r+1, c+1);
                }
            }
            return dataEntryForm;
        }
    }
}
