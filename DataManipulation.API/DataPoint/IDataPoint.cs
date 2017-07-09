using System;
using System.Collections.Generic;

namespace DataManipulation.API.DataPoint
{
    public interface IDataPoint
    {
        int Eid { get; set; }
        object Output { get; }
        event EventHandler<UpdateArgs> Update;
        void AddSubscriber(IDataPoint data, object change);
        void UnSubscribeTo(IDataPoint data);
        void SubscribeTo(IDataPoint data, object change);
        void UpdateSubscription(int eid, object newChange);
        void UpdateSubscriptions(List<int> eids, List<object> newChanges);
    }

    public class UpdateArgs : EventArgs
    {
        public Dictionary<int, object> Updates;
    }
}
