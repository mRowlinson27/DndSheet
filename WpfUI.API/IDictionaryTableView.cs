
namespace WpfUI.API
{
    using System;
    using Dtos;

    public interface IDictionaryTableView
    {
        event DictionaryTableUpdatedHandler DictionaryTableUpdated;

        void Update(DictionaryTable dictionaryTable);
    }

    public delegate void DictionaryTableUpdatedHandler(object sender, DictionaryTableUpdatedArgs a);

    public class DictionaryTableUpdatedArgs : EventArgs
    {
        public DictionaryTableUpdatedArgs(DictionaryTable dictionaryTable)
        {
            _dictionaryTable = dictionaryTable;
        }
        private DictionaryTable _dictionaryTable;
        public DictionaryTable Message
        {
            get { return _dictionaryTable; }
        }
    }
}
