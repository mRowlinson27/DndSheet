using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulation.API.EntryData
{
    public interface IEntryDataClient
    {
        object Output { get; }
        void UnSubscribeTo(IEntryData entryData);
        void SubscribeTo(IEntryData entryData, object currentChange);
    }
}
