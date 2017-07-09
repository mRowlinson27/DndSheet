using System.Collections.Generic;

namespace DataManipulation.API.DataPoint
{
    public interface IDataPointCalculateStrategy
    {
        object Calculate(object change);
        List<object> Calculate(List<object> changes);
    }
}
