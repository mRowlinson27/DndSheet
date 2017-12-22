
namespace WpfUI.API
{
    using System;
    using Dtos;

    public interface IDictionaryTableViewModel
    {
        event EventHandler<DictionaryTableUpdatedArgs> DictionaryTableUpdated;

        void Update(DictionaryTable dictionaryTable);
    }
}
