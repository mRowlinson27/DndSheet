using System.Collections.Generic;

namespace DataManipulation.API.Point
{
    public interface IPointCalculateStrategy
    {
        object Calculate(object change);
        List<object> Calculate(List<object> changes);
    }
}
