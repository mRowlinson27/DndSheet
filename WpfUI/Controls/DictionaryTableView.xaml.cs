namespace WpfUI.Controls
{
    using System.Windows.Controls;
    using System.Windows.Media;
    using API.Dtos;
    using Utilities.API;
    using ViewModels;
    using ViewModels.Helpers;
    using WpfUI.API;

    /// <summary>
    /// Interaction logic for Tables.xaml
    /// </summary>
    public partial class DictionaryTableView : IDictionaryTableView
    {
        public event DictionaryTableUpdatedHandler DictionaryTableUpdated;

        private DictionaryTableViewModel _dictionaryTableViewModel;

        public DictionaryTableView()
        {
            InitializeComponent();
        }
        
        public DictionaryTableView(IDictionaryTableViewModelHelper dictionaryTableViewModelHelper, ILogger logger)
        {
            InitializeComponent();
            DataGrid.Background = Brushes.MediumOrchid;
            _dictionaryTableViewModel = new DictionaryTableViewModel(this, dictionaryTableViewModelHelper, logger);
            DataContext = _dictionaryTableViewModel;
        }

        public void Update(DictionaryTable dictionaryTable)
        {
            _dictionaryTableViewModel.Update(dictionaryTable);
        }
    }
}
