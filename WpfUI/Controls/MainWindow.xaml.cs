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
    }
}
