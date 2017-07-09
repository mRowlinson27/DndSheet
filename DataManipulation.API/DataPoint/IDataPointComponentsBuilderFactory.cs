using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulation.API.DataPoint
{
    public interface IDataPointComponentsBuilderFactory
    {
        IDataPointComponentsBuilder Create(string value, IDataPointClientFactory dataPointClientFactory, IDataPointServerFactory dataPointServerFactory, IDataPointCalculateStrategy dataPointCalculateStrategy);
    }
}
