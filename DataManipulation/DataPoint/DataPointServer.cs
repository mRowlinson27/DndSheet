using System;
using System.Collections.Generic;
using DataManipulation.API.DataPoint;

namespace DataManipulation.DataPoint
{
    public class DataPointServer : IDataPointServer
    {
        private IDataPoint _dataPoint;
        private readonly IDataPointCalculateStrategy _dataPointCalculateStrategy;

        public DataPointServer(IDataPoint dataPoint, IDataPointCalculateStrategy dataPointCalculateStrategy)
        {
            _dataPoint = dataPoint;
            _dataPointCalculateStrategy = dataPointCalculateStrategy;
        }

        public void AddSubscriber(IDataPoint subscriber, object value)
        {
            if (_dataPoint.Eid == subscriber.Eid)
            {
                throw new InvalidOperationException();
            }
            var entry = _dataPointCalculateStrategy.Calculate(value);
            subscriber.SubscribeTo(_dataPoint, entry);
        }

        public UpdateArgs UpdateSubscription(int eid, object change)
        {
            var data = _dataPointCalculateStrategy.Calculate(change);
            return new UpdateArgs() {Updates = null};
        }

        public UpdateArgs UpdateSubscriptions(List<int> eids, List<object> changes)
        {
            var data = _dataPointCalculateStrategy.Calculate(changes);
            return new UpdateArgs() { Updates = null };
        }
    }
}
