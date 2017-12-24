
namespace WpfUI.ViewModels
{
    using System;
    using API;
    using API.Dtos;
    using Utilities.API;

    public class DictionaryTableDecoratorViewModel : ViewModelBase, IDictionaryTableDecoratorViewModel
    {
        private IDictionaryTableDecoratorView _view;
        private IDictionaryTableView _child;
        private readonly ILogger _logger;

        public event EventHandler<DictionaryTableUpdatedArgs> DictionaryTableUpdated;

        public IDictionaryTableView DictionaryTableViewBinding
        {
            get { return _child; }

            set
            {
                _child = value;
                OnPropertyChanged("DictionaryTableViewBinding");
            }
        }

        public DictionaryTableDecoratorViewModel(IDictionaryTableDecoratorView view,
            IDictionaryTableView child, ILogger logger)
        {
            _view = view;
            _child = child;
            _logger = logger;
        }
        
        public void Update(DictionaryTable dictionaryTable)
        {
            _child.Update(dictionaryTable);
        }

        public void AllowEditing()
        {
            _child.AllowEditing();
        }

        public void DisallowEditing()
        {
            _child.DisallowEditing();
        }
    }
}
