using DataManipulation.DTO;
using DataManipulation.Interfaces;

namespace DataManipulation
{
    public class PointFactory : IPointFactory
    {
        public IPoint Create(int eid, PointValue value)
        {
            return new Point(eid, value);
        }
    }
}
