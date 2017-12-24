namespace WpfUI.Factories
{
    using API;
    using API.Dtos;
    using Controls;
    using Utilities.API;
    using ViewModels;
    using ViewModels.Helpers;

    public class DictionaryTableFactory : IDictionaryTableFactory
    {
        private readonly ILogger _logger;

        public DictionaryTableFactory(ILogger logger)
        {
            _logger = logger;
        }

        public IDictionaryTableView Create()
        {
            var tablesView = new DictionaryTableView(
                new DictionaryTableViewModelHelper(_logger), _logger);
            return tablesView;
        }

        public IDictionaryTableDecoratorView CreateDecoratedView()
        {
            return new DictionaryTableDecoratorView(Create(), _logger);
        }
    }
}
