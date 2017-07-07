using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulation.API.EntryData
{
    public interface IEntryDataServer
    {
        void AddSubscriber(IEntryData subscriber, object change);
    }
}
