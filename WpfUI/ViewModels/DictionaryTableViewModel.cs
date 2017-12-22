namespace WpfUI.ViewModels
{
    using System;
    using System.Data;
    using System.Threading.Tasks;
    using API;
    using API.Dtos;
    using Helpers;
    using Utilities.API;

    public class DictionaryTableViewModel : ViewModelBase, IDictionaryTableView
    {
        public event EventHandler<DictionaryTableUpdatedArgs> DictionaryTableUpdated;
        
        private readonly IDictionaryTableView _dictionaryTableView;
        private readonly IDictionaryTableViewModelHelper _dictionaryTableViewModelHelper;
        private readonly ILogger _logger;

        private DataTable _dataGridBinding;
        public DataTable DataGridBinding
        {
            get { return _dataGridBinding; }

            set => DataGridBindingSetter(value);
        }

        private void DataGridBindingSetter(DataTable value)
        {
            if (_dataGridBinding != null)
            {
                _dataGridBinding.RowChanged -= DataGridBindingOnRowChanged;
            }

            _dataGridBinding = value;
            _dataGridBinding.RowChanged += DataGridBindingOnRowChanged;
            OnPropertyChanged("DataGridBinding");
            LogTable();
        }

        public DictionaryTableViewModel(IDictionaryTableView dictionaryTableView, IDictionaryTableViewModelHelper dictionaryTableViewModelHelper, ILogger logger)
        {
            _dictionaryTableView = dictionaryTableView;
            _dictionaryTableViewModelHelper = dictionaryTableViewModelHelper;
            _logger = logger;
        }

        public void Update(DictionaryTable dictionaryTable)
        {
            _logger.LogEntry();
            DataGridBinding = _dictionaryTableViewModelHelper.ConvertDictionaryTableToDataTable(dictionaryTable);
            _logger.LogExit();
        }

        private async void Initialize(DictionaryTable dictionaryTable)
        {
            _logger.LogEntry();
            //TODO: Make async later when getting data
            DataGridBinding = await Task.Run(() => _dictionaryTableViewModelHelper.ConvertDictionaryTableToDataTable(dictionaryTable));
            _dataGridBinding.RowChanged += DataGridBindingOnRowChanged;
            _logger.LogExit();
        }

        private void DataGridBindingOnRowChanged(object sender, DataRowChangeEventArgs dataRowChangeEventArgs)
        {
            _logger.LogEntry();
            var updatedTable = _dictionaryTableViewModelHelper.ConvertDataTableToDictionaryTable(_dataGridBinding);
            DictionaryTableUpdated?.Invoke(this, new DictionaryTableUpdatedArgs(updatedTable));
            LogTable();
        }

        private void LogTable()
        {
            _logger.LogEntry();
            foreach (DataColumn col in _dataGridBinding.Columns)
            {
                foreach (DataRow row in _dataGridBinding.Rows)
                {
                    _logger.LogMessage(row[col.ColumnName].ToString());
                }
            }
        }

        
    }
}
