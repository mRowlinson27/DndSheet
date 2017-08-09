using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.DTOs;
using DataManipulation.API.Point;

namespace DataManipulation.Point
{
    public class PointFactory : IPointFactory
    {
        public IPoint Create(int eid, PointValue value)
        {
            return new Point(eid, value);
        }
    }
}
