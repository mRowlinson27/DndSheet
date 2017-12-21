namespace WpfUI.ViewModels
{
    using API;
    using API.Dtos;
    using DictionaryTableView = Controls.DictionaryTableView;

    class MainViewModel : ViewModelBase
    {
        public IDictionaryTableView MainWindowTablesViewBinding
        {
            get { return _dictionaryTableView; }
            set
            {
                _dictionaryTableView = value;
                OnPropertyChanged("MainWindowTablesView");
            }
        }

        private IDictionaryTableView _dictionaryTableView;

        public MainViewModel(IDictionaryTableView dictionaryTableView)
        {
            MainWindowTablesViewBinding = dictionaryTableView;
        }

        public MainViewModel(IDictionaryTableFactory dictionaryTableFactory)
        {
            MainWindowTablesViewBinding = dictionaryTableFactory.Create(new DictionaryTable());
        }
    }
}
