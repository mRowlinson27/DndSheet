using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API;
using DataManipulation.API.DataPoint;
using SqlDatabase.API;

namespace DataManipulation
{
    public class DataRestoreStrategy : IDataRestoreStrategy
    {
        private readonly IDictionaryGraphNodeFactory<IDataPoint> _dictionaryGraphNodeFactory;

        public DataRestoreStrategy(IDictionaryGraphNodeFactory<IDataPoint> dictionaryGraphNodeFactory)
        {
            _dictionaryGraphNodeFactory = dictionaryGraphNodeFactory;
        }

        public void CreateAllPoints()
        {
            
        }

        public IDictionaryGraphNode<IDataPoint> RestoreTree(IDatabaseAdaptor databaseAccessor)
        {
            var head = databaseAccessor.FindEntityByEid("Head");

            var graph = _dictionaryGraphNodeFactory.Create(0, null);
            var headings = databaseAccessor.FindEntitiesByDatatype("Heading");



            return null;
        }
    }
}
