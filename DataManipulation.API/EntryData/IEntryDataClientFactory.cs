using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulation.API.EntryData
{
    public interface IEntryDataClientFactory
    {
        IEntryDataClient Create(IEntryData entryData, object value);
    }
}
