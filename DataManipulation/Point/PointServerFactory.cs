using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.Point;

namespace DataManipulation.Point
{
    public class PointServerFactory : IPointServerFactory
    {
        public IPointServer Create(IPoint point, IPointCalculateStrategy pointCalculateStrategy)
        {
            return new PointServer(point, pointCalculateStrategy);
        }
    }
}
