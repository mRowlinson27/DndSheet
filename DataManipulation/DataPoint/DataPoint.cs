using System;
using System.Collections.Generic;
using DataManipulation.API.DataPoint;

namespace DataManipulation.DataPoint
{
    public class DataPoint : IDataPoint
    {
        public int Eid { get; set; }
        public object Output { get { return _dataPointClient.Output; } }
        public event EventHandler<UpdateArgs> Update;
        private readonly IDataPointServer _dataPointServer;
        private readonly IDataPointClient _dataPointClient;

        public DataPoint(int eid, IDataPointComponentsBuilder dataPointComponentsBuilder)
        {
            Eid = eid;
            _dataPointServer = dataPointComponentsBuilder.CreateServer(this);
            _dataPointClient = dataPointComponentsBuilder.CreateClient(this);
        }

        public void AddSubscriber(IDataPoint subscriber, object change)
        {
            _dataPointServer.AddSubscriber(subscriber, change);
        }

        public void UnSubscribeTo(IDataPoint dataPoint)
        {
            _dataPointClient.UnSubscribeTo(dataPoint);
        }

        public void SubscribeTo(IDataPoint dataPoint, object currentChange)
        {
            _dataPointClient.SubscribeTo(dataPoint, currentChange);
        }

        public void UpdateSubscription(int eid, object newChange)
        {
            OnUpdate(_dataPointServer.UpdateSubscription(eid, newChange));
        }

        public void UpdateSubscriptions(List<int> eids, List<object> newChanges)
        {
            OnUpdate(_dataPointServer.UpdateSubscriptions(eids, newChanges));
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
