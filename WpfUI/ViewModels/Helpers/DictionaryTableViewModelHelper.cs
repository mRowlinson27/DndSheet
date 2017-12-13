
namespace WpfUI.ViewModels.Helpers
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using Dtos;

    public class DictionaryTableViewModelHelper : IDictionaryTableViewModelHelper
    {
        private readonly DictionaryTable _dictionaryTable;

        public DictionaryTableViewModelHelper(DictionaryTable dictionaryTable)
        {
            _dictionaryTable = dictionaryTable;
        }

        public DataTable GetSource()
        {
            var dataTable = new DataTable();

            foreach (var heading in _dictionaryTable.Headings)
            {
                dataTable.Columns.Add(new DataColumn(heading.HeadingName, heading.ColumnType));
            }
            foreach (var row in _dictionaryTable.Rows)
            {
                var rowData = new List<object>();
                foreach (var heading in _dictionaryTable.Headings)
                {
                    rowData.Add(row[heading.HeadingName]);
                }
                dataTable.Rows.Add(rowData.ToArray());
            }
            return dataTable;
        }
    }
}
