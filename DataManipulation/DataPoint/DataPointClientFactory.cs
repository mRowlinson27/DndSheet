using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.DataPoint;

namespace DataManipulation.DataPoint
{
    public class DataPointClientFactory : IDataPointClientFactory
    {
        public IDataPointClient Create(IDataPoint dataPoint, object value)
        {
            return new DataPointClient(dataPoint, value);
        }
    }
}
