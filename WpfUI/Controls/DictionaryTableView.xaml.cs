namespace WpfUI.Controls
{
    using System.Windows.Controls;
    using System.Windows.Media;
    using WpfUI.API;

    /// <summary>
    /// Interaction logic for Tables.xaml
    /// </summary>
    public partial class DictionaryTableView : IDictionaryTableView
    {
        public DictionaryTableView()
        {
            InitializeComponent();
            DataGrid.Background = Brushes.MediumOrchid;
        }
    }
}
