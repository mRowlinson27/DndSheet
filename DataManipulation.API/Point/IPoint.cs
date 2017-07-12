using System;
using System.Collections.Generic;

namespace DataManipulation.API.Point
{
    public interface IPoint
    {
        int Eid { get; set; }
        object Output { get; }
        event EventHandler<UpdateArgs> Update;
        void AddSubscriber(IPoint data, object change);
        void UnSubscribeTo(IPoint data);
        void SubscribeTo(IPoint data, object change);
        void UpdateSubscription(int eid, object newChange);
        void UpdateSubscriptions(List<int> eids, List<object> newChanges);
    }

    public class UpdateArgs : EventArgs
    {
        public Dictionary<int, object> Updates;
    }
}
