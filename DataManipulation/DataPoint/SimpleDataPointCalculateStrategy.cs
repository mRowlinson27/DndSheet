using System.Collections.Generic;
using DataManipulation.API.DataPoint;

namespace DataManipulation.DataPoint
{
    class SimpleDataPointCalculateStrategy : IDataPointCalculateStrategy
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
