
namespace WpfUI.ViewModels.Helpers
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;
    using API.Dtos;
    using Utilities.API;

    public class DictionaryTableViewModelHelper : IDictionaryTableViewModelHelper
    {
        private readonly ILogger _logger;

        public DictionaryTableViewModelHelper(ILogger logger)
        {
            _logger = logger;
        }

        public DataTable ConvertDictionaryTableToDataTable(DictionaryTable dictionaryTable)
        {
            _logger.LogEntry();
            Thread.Sleep(3000);

            var dataTable = new DataTable();

            foreach (var heading in dictionaryTable.Headings)
            {
                dataTable.Columns.Add(new DataColumn(heading.HeadingName, heading.ColumnType));
            }
            foreach (var row in dictionaryTable.Rows)
            {
                var rowData = new List<object>();
                foreach (var heading in dictionaryTable.Headings)
                {
                    rowData.Add(row[heading.HeadingName]);
                }
                dataTable.Rows.Add(rowData.ToArray());
            }
            _logger.LogExit();
            return dataTable;
        }

        public DictionaryTable ConvertDataTableToDictionaryTable(DataTable dataTable)
        {
            throw new System.NotImplementedException();
        }
    }
}
