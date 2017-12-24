namespace WpfUI.Controls
{
    using System.Threading.Tasks;
    using System.Windows;
    using API;
    using Utilities.API;
    using ViewModels;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        public ILogger Logger {
            get => _mainViewModel.Logger;
            set => _mainViewModel.Logger = value;
        }

        public IDictionaryTableFactory DictionaryTableFactory
        {
            get => _mainViewModel.DictionaryTableFactory;
            set => _mainViewModel.DictionaryTableFactory = value;
        }

        private MainViewModel _mainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            
            _mainViewModel = new MainViewModel(this);
            DataContext = _mainViewModel;
        }

        public void Initialize()
        {
            _mainViewModel.Initialize();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to close this window?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                
            }
        }

        private void AddColumnButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainViewModel.AllowEditing();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainViewModel.CancelEditing();
        }
    }
}
