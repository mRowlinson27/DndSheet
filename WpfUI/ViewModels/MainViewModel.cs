namespace WpfUI.ViewModels
{
    using DictionaryTableView = Controls.DictionaryTableView;

    class MainViewModel : ViewModelBase
    {
        public DictionaryTableView MainWindowTablesViewBinding
        {
            get { return _dictionaryTableView; }
            set
            {
                _dictionaryTableView = value;
                OnPropertyChanged("MainWindowTablesView");
            }
        }

        private DictionaryTableView _dictionaryTableView;

        public MainViewModel(DictionaryTableView dictionaryTableView)
        {
            _dictionaryTableView = dictionaryTableView;
        }
    }
}
