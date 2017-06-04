using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API;
using CustomForms.API.Builders;
using CustomForms.API.Factories;

namespace CustomForms.Builders
{
    public class TableLayoutBuilder : ITableLayoutBuilder
    {
        private ILabelWrapperFactory _labelWrapperFactory;
        public TableLayoutBuilder(ILabelWrapperFactory labelWrapperFactory)
        {
            _labelWrapperFactory = labelWrapperFactory;
        }

        public IDataEntryForm Create(List<List<string>> dataListofList)
        {
            var dataEntryForm = new DataEntryForm();
            return Build(dataEntryForm, dataListofList);
        }

        public IDataEntryForm Apply(IDataEntryForm dataEntryForm, List<List<string>> dataListofList)
        {
            return Build(dataEntryForm, dataListofList);
        }

        private IDataEntryForm Build(IDataEntryForm dataEntryForm, List<List<string>> dataListofList)
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
                    dataEntryForm.InsertControl(_labelWrapperFactory.Create(dataListofList[r][c]), r+1, c+1);
                }
            }
            return dataEntryForm;
        }
    }
}
