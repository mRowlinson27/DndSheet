using System;
using System.Collections.Generic;
using System.Linq;
using DataManipulation.API;
using DataManipulation.API.Point;
using SqlDatabase.API;
using Utilities.API;

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

        public Dictionary<int,IPoint> CreateAllPoints(IDatabase database)
        {
            var points = new Dictionary<int, IPoint>();
            var entities = database.FindEntitiesByDatatype("Point");

            return points;
        }

        public IDictionaryGraphNode<IPoint> RestoreTree(string headName, IDatabase database)
        {
            var heads = database.FindEntitiesByDatatype("Head");
            var head = heads.FirstOrDefault(x => x.Value == headName);

            var graph = _dictionaryGraphNodeFactory.Create(head.Eid, null);
            var headings = database.FindEntitiesByDatatype("GraphNode");



            return null;
        }
    }
}
