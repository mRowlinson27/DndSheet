
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

            PopulateDataTableColumns(dictionaryTable, dataTable);
            PopulateDataTableRows(dictionaryTable, dataTable);

            _logger.LogExit();
            return dataTable;
        }

        private void PopulateDataTableColumns(DictionaryTable dictionaryTable, DataTable dataTable)
        {
            foreach (var heading in dictionaryTable.Headings)
            {
                dataTable.Columns.Add(new DataColumn(heading.HeadingName, heading.ColumnType));
            }
        }

        private void PopulateDataTableRows(DictionaryTable dictionaryTable, DataTable dataTable)
        {
            foreach (var row in dictionaryTable.Rows)
            {
                dataTable.Rows.Add(GetRowArrayFromDictionaryTable(dictionaryTable.Headings, row));
            }
        }

        private object[] GetRowArrayFromDictionaryTable(List<ColumnHeading> headings, Dictionary<string, object> row)
        {
            var rowData = new List<object>();
            foreach (var heading in headings)
            {
                if (row.ContainsKey(heading.HeadingName))
                {
                    rowData.Add(row[heading.HeadingName]);
                }
                else
                {
                    rowData.Add(GetDefault(heading.ColumnType));
                }
            }
            return rowData.ToArray();
        }

        private object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
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
