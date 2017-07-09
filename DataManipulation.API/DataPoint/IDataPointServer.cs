using System.Collections.Generic;

namespace DataManipulation.API.DataPoint
{
    public interface IDataPointServer
    {
        void AddSubscriber(IDataPoint subscriber, object value);
        UpdateArgs UpdateSubscription(int eid, object change);
        UpdateArgs UpdateSubscriptions(List<int> eids, List<object> change);
    }
}
