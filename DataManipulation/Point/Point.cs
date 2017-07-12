using System;
using System.Collections.Generic;
using DataManipulation.API.Point;

namespace DataManipulation.Point
{
    public class Point : IPoint
    {
        public int Eid { get; set; }
        public object Output { get { return _pointClient.Output; } }
        public event EventHandler<UpdateArgs> Update;
        private readonly IPointServer _pointServer;
        private readonly IPointClient _pointClient;

        public Point(int eid, IPointComponentsBuilder pointComponentsBuilder)
        {
            Eid = eid;
            _pointServer = pointComponentsBuilder.CreateServer(this);
            _pointClient = pointComponentsBuilder.CreateClient(this);
        }

        public void AddSubscriber(IPoint subscriber, object change)
        {
            _pointServer.AddSubscriber(subscriber, change);
        }

        public void UnSubscribeTo(IPoint point)
        {
            _pointClient.UnSubscribeTo(point);
        }

        public void SubscribeTo(IPoint point, object currentChange)
        {
            _pointClient.SubscribeTo(point, currentChange);
        }

        public void UpdateSubscription(int eid, object newChange)
        {
            OnUpdate(_pointServer.UpdateSubscription(eid, newChange));
        }

        public void UpdateSubscriptions(List<int> eids, List<object> newChanges)
        {
            OnUpdate(_pointServer.UpdateSubscriptions(eids, newChanges));
        }

        protected virtual void OnUpdate(UpdateArgs args)
        {
            if (Update != null)
            {
                Update.Invoke(this, args);
            }
        }
    }
}
