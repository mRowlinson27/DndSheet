using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API;
using DataManipulation.API.EntryData;

namespace DataManipulation.EntryData
{
    public class EntryData : IEntryData
    {
        public int Eid { get; set; }
        public object Output { get { return _entryDataClient.Output; } }
        public event EventHandler Update;
        private readonly IEntryDataServer _entryDataServer;
        private readonly IEntryDataClient _entryDataClient;

        public EntryData(int eid, object value, IEntryDataClientFactory entryDataClientFactory, IEntryDataServerFactory entryDataServerFactory)
        {
            Eid = eid;
            _entryDataServer = entryDataServerFactory.Create(this);
            _entryDataClient = entryDataClientFactory.Create(this, value);
        }

        public void AddSubscriber(IEntryData subscriber, object change)
        {
            _entryDataServer.AddSubscriber(subscriber, change);
        }

        public void UnSubscribeTo(IEntryData entryData)
        {
            _entryDataClient.UnSubscribeTo(entryData);
        }

        public void SubscribeTo(IEntryData entryData, object currentChange)
        {
            _entryDataClient.SubscribeTo(entryData, currentChange);
        }

        protected virtual void OnUpdate()
        {
            if (Update != null)
            {
                Update.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
