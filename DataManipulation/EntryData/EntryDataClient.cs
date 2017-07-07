using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API;
using DataManipulation.API.EntryData;

namespace DataManipulation.EntryData
{
    public class EntryDataClient : IEntryDataClient
    {
        private readonly IEntryData _entryData;
        private object _value;
        private object _output;
        public object Output { get { return _output; } }

        public EntryDataClient(IEntryData entryData, object value)
        {
            _entryData = entryData;
            _value = value;
            _output = value;
        }

        public void UnSubscribeTo(IEntryData entryData)
        {
            throw new NotImplementedException();
        }

        public void SubscribeTo(IEntryData entryData, object currentChange)
        {
            if (currentChange.GetType() != _value.GetType())
            {
                throw new InvalidOperationException();
            }
            if (currentChange is string)
            {
                _output = currentChange;
            }
        }
    }
}
