namespace WpfUI.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API;
    using API.Dtos;
    using Utilities.API;

    public class MainViewModel : ViewModelBase, IMainWindow, IMainViewModel
    {
        //Bindings -------------------------------

        public IDictionaryTableDecoratorView MainWindowTablesViewBinding
        {
            get { return _dictionaryTableView; }
            set
            {
                _dictionaryTableView = value;
                OnPropertyChanged("MainWindowTablesView");
            }
        }
        private IDictionaryTableDecoratorView _dictionaryTableView;

        //Properties -------------------------------

        public ILogger Logger { get; set; }
        public IDictionaryTableFactory DictionaryTableFactory { get; set; }

        private readonly IMainWindow _mainWindow;

        public MainViewModel(IMainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public void Initialize()
        {
            Logger.LogEntry();
            _oldTable = new DictionaryTable()
            {
                Headings = new List<ColumnHeading>
                {
                    new ColumnHeading()
                    {
                        ColumnType = typeof(string),
                        HeadingName = "Skill Name"
                    },
                    new ColumnHeading()
                    {
                        ColumnType = typeof(bool),
                        HeadingName = "Description"
                    },
                    new ColumnHeading()
                    {
                        ColumnType = typeof(int),
                        HeadingName = "Ranks"
                    }
                },
                Rows = new List<Dictionary<string, object>>
                {
                    new Dictionary<string, object>
                    {
                        {"Skill Name", "Acro"},
                        {"Description",  true},
                        {"Ranks", 1}
                    },
                    new Dictionary<string, object>
                    {
                        {"Skill Name", "Climb"},
                        {"Description",  false},
                        {"Ranks", 3}
                    }
                }
            };
            MainWindowTablesViewBinding = DictionaryTableFactory.CreateDecoratedView();
            MainWindowTablesViewBinding.Update(_oldTable);
            MainWindowTablesViewBinding.DictionaryTableUpdated += OnDictionaryTableUpdated;
            Logger.LogExit();
        }

        private void OnDictionaryTableUpdated(object sender, DictionaryTableUpdatedArgs dictionaryTableUpdatedArgs)
        {
            Logger.LogEntry();
        }

        private DictionaryTable _oldTable;
        public void AllowEditing()
        {
            MainWindowTablesViewBinding.AllowEditing();
        }

        public void CancelEditing()
        {
            MainWindowTablesViewBinding.Update(_oldTable);
            MainWindowTablesViewBinding.DisallowEditing();
        }
    }
}
