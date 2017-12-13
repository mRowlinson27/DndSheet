namespace WpfUI.Controls
{
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for Tables.xaml
    /// </summary>
    public partial class DictionaryTableView : UserControl
    {
        public DictionaryTableView()
        {
            InitializeComponent();
            DataGrid.Background = Brushes.MediumOrchid;
        }
    }
}
