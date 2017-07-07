using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API;
using DataManipulation.API.EntryData;

namespace DataManipulation.EntryData
{
    public class EntryDataServer : IEntryDataServer
    {
        private IEntryData _entryData;
        public EntryDataServer(IEntryData entryData)
        {
            _entryData = entryData;
        }

        public void AddSubscriber(IEntryData subscriber, object change)
        {
            if (_entryData.Eid == subscriber.Eid)
            {
                throw new InvalidOperationException();
            }
            subscriber.SubscribeTo(_entryData, change);
        }
    }
}
