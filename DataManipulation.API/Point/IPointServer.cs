using System.Collections.Generic;

namespace DataManipulation.API.Point
{
    public interface IPointServer
    {
        void AddSubscriber(IPoint subscriber, object value);
        UpdateArgs UpdateSubscription(int eid, object change);
        UpdateArgs UpdateSubscriptions(List<int> eids, List<object> change);
    }
}
