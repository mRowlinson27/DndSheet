namespace WpfUI.Factories
{
    using API;
    using API.Dtos;
    using Controls;
    using ViewModels;
    using ViewModels.Helpers;

    public class DictionaryTableFactory : IDictionaryTableFactory
    {
        public DictionaryTableFactory()
        {
            
        }

        public IDictionaryTableView Create(DictionaryTable dictionaryTable)
        {
            var dictionaryTableViewModel = new DictionaryTableViewModel(
                new DictionaryTableViewModelHelper(dictionaryTable));
            var tablesView = new DictionaryTableView
            {
                DataContext = dictionaryTableViewModel,
            };
            return tablesView;
        }
    }
}
