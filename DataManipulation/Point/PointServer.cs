using System;
using System.Collections.Generic;
using DataManipulation.API.Point;

namespace DataManipulation.Point
{
    public class PointServer : IPointServer
    {
        private IPoint _point;
        private readonly IPointCalculateStrategy _pointCalculateStrategy;

        public PointServer(IPoint point, IPointCalculateStrategy pointCalculateStrategy)
        {
            _point = point;
            _pointCalculateStrategy = pointCalculateStrategy;
        }

        public void AddSubscriber(IPoint subscriber, object value)
        {
            if (_point.Eid == subscriber.Eid)
            {
                throw new InvalidOperationException();
            }
            var entry = _pointCalculateStrategy.Calculate(value);
            subscriber.SubscribeTo(_point, entry);
        }

        public UpdateArgs UpdateSubscription(int eid, object change)
        {
            var data = _pointCalculateStrategy.Calculate(change);
            return new UpdateArgs() {Updates = null};
        }

        public UpdateArgs UpdateSubscriptions(List<int> eids, List<object> changes)
        {
            var data = _pointCalculateStrategy.Calculate(changes);
            return new UpdateArgs() { Updates = null };
        }
    }
}
