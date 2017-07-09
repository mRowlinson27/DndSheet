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
        private readonly IDataPointBuilder _dataPointBuilder;
        private readonly IDictionaryGraphNodeFactory<IDataPoint> _dictionaryGraphNodeFactory;

        public DataRestoreStrategy(IDataPointBuilder dataPointBuilder, IDictionaryGraphNodeFactory<IDataPoint> dictionaryGraphNodeFactory)
        {
            _dataPointBuilder = dataPointBuilder;
            _dictionaryGraphNodeFactory = dictionaryGraphNodeFactory;
        }

        public Dictionary<int,IDataPoint> CreateAllPoints(IDatabaseControl databaseControl)
        {
            var points = new Dictionary<int, IDataPoint>();
            var entities = databaseControl.FindAllEntities();

            foreach (var entity in entities)
            {
                var point = _dataPointBuilder.BuildPoint(entity);
                points.Add(point.Eid, point);
            }

            foreach (var point in points.Values)
            {
                var predicates = databaseControl.FindPredicatesAffectedBySubject(point.Eid);
                foreach (var predicate in predicates)
                {
                    point.AddSubscriber(points[predicate.Subject], predicate.Relationship);
                }
            }
            return points;
        }

        public IDictionaryGraphNode<IDataPoint> RestoreTree(IDatabaseAdaptor databaseAdaptor)
        {
            var head = databaseAdaptor.FindEntityByEid("Head");

            var graph = _dictionaryGraphNodeFactory.Create(0, null);
            var headings = databaseAdaptor.FindEntitiesByDatatype("Heading");



            return null;
        }
    }
}
