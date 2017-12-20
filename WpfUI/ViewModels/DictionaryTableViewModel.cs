namespace WpfUI.ViewModels
{
    using System.Data;
    using System.Threading.Tasks;
    using Helpers;

    public class DictionaryTableViewModel : ViewModelBase
    {
        private readonly IDictionaryTableViewModelHelper _dictionaryTableViewModelHelper;

        private DataTable _dataGridBinding;
        public DataTable DataGridBinding
        {
            get
            {
                return _dataGridBinding;
            }

            private set { _dataGridBinding = value; OnPropertyChanged(); }
        }

        public DictionaryTableViewModel(IDictionaryTableViewModelHelper dictionaryTableViewModelHelper)
        {
            _dictionaryTableViewModelHelper = dictionaryTableViewModelHelper;
            Initialize();
        }

        private async void Initialize()
        {
            _dataGridBinding = await Task.Run(() => _dictionaryTableViewModelHelper.GetSource());
            OnPropertyChanged("DataGridBinding");
        }
    }
}
