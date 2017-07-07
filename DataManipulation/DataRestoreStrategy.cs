using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API;
using DataManipulation.API.EntryData;
using DataManipulation.EntryData;
using DataManipulation.Taggables;
using SqlDatabase.API;

namespace DataManipulation
{
    public class DataRestoreStrategy : IDataRestoreStrategy
    {
        private readonly IDictionaryGraphNodeFactory<IEntryData> _dictionaryGraphNodeFactory;

        public DataRestoreStrategy(IDictionaryGraphNodeFactory<IEntryData> dictionaryGraphNodeFactory)
        {
            _dictionaryGraphNodeFactory = dictionaryGraphNodeFactory;
        }

        public IDictionaryGraphNode<IEntryData> RestoreTree(IDatabaseAdaptor databaseAccessor)
        {
            var head = databaseAccessor.FindEntityByEid("Head");

            var graph = _dictionaryGraphNodeFactory.Create(0, null);
            var headings = databaseAccessor.FindEntitiesByDatatype("Heading");



            return null;
        }
    }
}
