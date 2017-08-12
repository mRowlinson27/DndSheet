using DataManipulation.DTO;

namespace DataManipulation.Interfaces
{
    public interface IPointFactory
    {
        IPoint Create(int eid, PointValue value);
    }
}
