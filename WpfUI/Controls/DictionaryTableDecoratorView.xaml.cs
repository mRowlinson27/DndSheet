
namespace WpfUI.Controls
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using API;
    using API.Dtos;
    using Utilities.API;
    using ViewModels;
    using ViewModels.Helpers;

    /// <summary>
    /// Interaction logic for DictionaryTableDecoratorView.xaml
    /// </summary>
    public partial class DictionaryTableDecoratorView : UserControl, IDictionaryTableDecoratorView
    {
        private readonly ILogger _logger;
        private readonly IDictionaryTableDecoratorViewModel _viewModel;

        public event EventHandler<DictionaryTableUpdatedArgs> DictionaryTableUpdated;

        public DictionaryTableDecoratorView()
        {
            InitializeComponent();
        }

        public DictionaryTableDecoratorView(IDictionaryTableView dictionaryTableView,
            ILogger logger)
        {
            _logger = logger;
            InitializeComponent();
            _viewModel = new DictionaryTableDecoratorViewModel(this, dictionaryTableView, _logger);
            ApplyViewModelBindings();
        }

        private void ApplyViewModelBindings()
        {
            DataContext = _viewModel;
            _viewModel.DictionaryTableUpdated += OnDictionaryTableUpdated;
        }

        public void Update(DictionaryTable dictionaryTable)
        {
            _viewModel.Update(dictionaryTable);
        }

        public void AllowEditing()
        {
            _viewModel.AllowEditing();
        }

        public void DisallowEditing()
        {
            _viewModel.DisallowEditing();
        }

        private void OnDictionaryTableUpdated(object sender, DictionaryTableUpdatedArgs e)
        {
            DictionaryTableUpdated?.Invoke(sender, e);
        }
    }
}
