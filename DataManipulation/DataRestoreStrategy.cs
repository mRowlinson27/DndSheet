using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API;
using DataManipulation.API.Point;
using SqlDatabase.API;

namespace DataManipulation
{
    public class DataRestoreStrategy : IDataRestoreStrategy
    {
        private readonly IPointBuilder _pointBuilder;
        private readonly IDictionaryGraphNodeFactory<IPoint> _dictionaryGraphNodeFactory;

        public DataRestoreStrategy(IPointBuilder pointBuilder, IDictionaryGraphNodeFactory<IPoint> dictionaryGraphNodeFactory)
        {
            _pointBuilder = pointBuilder;
            _dictionaryGraphNodeFactory = dictionaryGraphNodeFactory;
        }

        public Dictionary<int,IPoint> CreateAllPoints(IDatabaseControl databaseControl)
        {
            var points = new Dictionary<int, IPoint>();
            var entities = databaseControl.FindEntitiesByDatatype("Point");

            return points;
        }

        public IDictionaryGraphNode<IPoint> RestoreTree(string headName, IDatabaseControl databaseControl)
        {
            var heads = databaseControl.FindEntitiesByDatatype("Head");
            var head = heads.FirstOrDefault(x => x.Value == headName);

            var graph = _dictionaryGraphNodeFactory.Create(head.Eid, null);
            var headings = databaseControl.FindEntitiesByDatatype("GraphNode");



            return null;
        }
    }
}
