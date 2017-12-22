namespace WpfUI.Controls
{
    using System;
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
        private readonly ILogger _logger;
        public event EventHandler<DictionaryTableUpdatedArgs> DictionaryTableUpdated;

        private IDictionaryTableViewModel _dictionaryTableViewModel;

        public DictionaryTableView()
        {
            InitializeComponent();
        }
        
        public DictionaryTableView(IDictionaryTableViewModelHelper dictionaryTableViewModelHelper, ILogger logger)
        {
            _logger = logger;
            InitializeComponent();
            DataGrid.Background = Brushes.MediumOrchid;
            _dictionaryTableViewModel = new DictionaryTableViewModel(this, dictionaryTableViewModelHelper, logger);
            ApplyViewModelBindings();
        }

        private void ApplyViewModelBindings()
        {
            DataContext = _dictionaryTableViewModel;
            _dictionaryTableViewModel.DictionaryTableUpdated += OnDictionaryTableUpdated;
        }

        private void OnDictionaryTableUpdated(object sender, DictionaryTableUpdatedArgs dictionaryTableUpdatedArgs)
        {
            DictionaryTableUpdated?.Invoke(sender, dictionaryTableUpdatedArgs);
        }

        public void Update(DictionaryTable dictionaryTable)
        {
            _dictionaryTableViewModel.Update(dictionaryTable);
        }

        public void AllowEditing()
        {
            DataGrid.IsReadOnly = false;
        }

        public void DisallowEditing()
        {
            DataGrid.IsReadOnly = true;
        }

        private void DataGrid_OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            _logger.LogEntry();
        }
    }
}
