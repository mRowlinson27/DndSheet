using System.Collections.Generic;
using DataManipulation.DTO;

namespace DataManipulation.Interfaces
{
    public interface IPointBuilder
    {
        IPoint BuildExistingPoint(int eid, PointValue value, List<IPointEquation> equations);
    }
}
