using System.Collections.Generic;
using DataManipulation.API.Point;

namespace DataManipulation.Point
{
    class SimplePointCalculateStrategy : IPointCalculateStrategy
    {
        public object Calculate(object change)
        {
            return change;
        }

        public List<object> Calculate(List<object> changes)
        {
            return changes;
        }
    }
}
