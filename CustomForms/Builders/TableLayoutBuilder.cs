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
        public IDataEntryForm Create(List<List<IControl>> dataListofList)
        {
            var dataEntryForm = new DataEntryForm();
            return Build(dataEntryForm, dataListofList);
        }

        public IDataEntryForm Apply(IDataEntryForm dataEntryForm, List<List<IControl>> dataListofList)
        {
            return Build(dataEntryForm, dataListofList);
        }

        private IDataEntryForm Build(IDataEntryForm dataEntryForm, List<List<IControl>> dataListofList)
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
