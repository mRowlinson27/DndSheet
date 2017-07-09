using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.DataPoint;

namespace DataManipulation.DataPoint
{
    public class DataPointServerFactory : IDataPointServerFactory
    {
        public IDataPointServer Create(IDataPoint dataPoint, IDataPointCalculateStrategy dataPointCalculateStrategy)
        {
            return new DataPointServer(dataPoint, dataPointCalculateStrategy);
        }
    }
}
