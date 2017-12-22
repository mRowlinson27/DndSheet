namespace WpfUI.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API;
    using API.Dtos;
    using Utilities.API;
    using DictionaryTableView = Controls.DictionaryTableView;

    public class MainViewModel : ViewModelBase, IMainWindow
    {
        //Bindings -------------------------------

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
            var dictionaryTable = new DictionaryTable()
            {
                Headings = new List<ColumnHeadings>
                {
                    new ColumnHeadings()
                    {
                        ColumnType = typeof(string),
                        HeadingName = "Skill Name"
                    },
                    new ColumnHeadings()
                    {
                        ColumnType = typeof(bool),
                        HeadingName = "Description"
                    },
                    new ColumnHeadings()
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
            MainWindowTablesViewBinding = DictionaryTableFactory.Create();
            MainWindowTablesViewBinding.Update(dictionaryTable);
            Logger.LogExit();
        }
    }
}
