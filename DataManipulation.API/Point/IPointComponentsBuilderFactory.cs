using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulation.API.Point
{
    public interface IPointComponentsBuilderFactory
    {
        IPointComponentsBuilder Create(string value, IPointClientFactory pointClientFactory, IPointServerFactory pointServerFactory, IPointCalculateStrategy pointCalculateStrategy);
    }
}
