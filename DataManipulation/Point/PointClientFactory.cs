using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.Point;

namespace DataManipulation.Point
{
    public class PointClientFactory : IPointClientFactory
    {
        public IPointClient Create(IPoint point, object value)
        {
            return new PointClient(point, value);
        }
    }
}
