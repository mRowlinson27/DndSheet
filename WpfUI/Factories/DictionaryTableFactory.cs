using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI.Factories
{
    using Controls;
    using Dtos;
    using ViewModels;
    using ViewModels.Helpers;

    public class DictionaryTableFactory
    {
        public DictionaryTableFactory()
        {
            
        }

        public DictionaryTableView Create(DictionaryTable dictionaryTable)
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
