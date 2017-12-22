
namespace WpfUI.API
{
    using System;
    using Dtos;

    public interface IDictionaryTableView
    {
        event EventHandler<DictionaryTableUpdatedArgs> DictionaryTableUpdated;

        void Update(DictionaryTable dictionaryTable);
    }

    public class DictionaryTableUpdatedArgs : EventArgs
    {
        public DictionaryTableUpdatedArgs(DictionaryTable dictionaryTable)
        {
            _dictionaryTable = dictionaryTable;
        }
        private DictionaryTable _dictionaryTable;
        public DictionaryTable DictionaryTable
        {
            get { return _dictionaryTable; }
        }
    }
}
