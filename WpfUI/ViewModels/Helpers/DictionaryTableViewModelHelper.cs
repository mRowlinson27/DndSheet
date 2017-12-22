
namespace WpfUI.ViewModels.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
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
                    Console.WriteLine(row[heading.HeadingName]);
                    rowData.Add(row[heading.HeadingName]);
                }
                dataTable.Rows.Add(rowData.ToArray());
            }
            _logger.LogExit();
            return dataTable;
        }

        public DictionaryTable ConvertDataTableToDictionaryTable(DataTable dataTable)
        {
            var dictionaryTable = new DictionaryTable();
            dictionaryTable.Headings = new List<ColumnHeading>();
            dictionaryTable.Rows = new List<Dictionary<string, object>>();

            foreach (DataColumn col in dataTable.Columns)
            {
                var columnHeading = new ColumnHeading()
                {
                    HeadingName = col.ColumnName,
                    ColumnType = col.DataType
                };
                dictionaryTable.Headings.Add(columnHeading);
            }

            foreach (DataRow row in dataTable.Rows)
            {
                var dictRow = new Dictionary<string, object>();
                foreach (DataColumn col in dataTable.Columns)
                {
                    dictRow.Add(col.ColumnName, row[col.ColumnName]);
                }
                dictionaryTable.Rows.Add(dictRow);
            }

            return dictionaryTable;
        }
    }
}
