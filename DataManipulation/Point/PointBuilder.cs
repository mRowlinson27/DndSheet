using System.Collections.Generic;
using DataManipulation.API.DTOs;
using DataManipulation.API.Point;
using SqlDatabase.API.DTO;

namespace DataManipulation.Point
{
    public class PointBuilder : IPointBuilder
    {
        private readonly IPointFactory _pointFactory;
        private readonly IPointCalculateStrategy _simpleCalculateStrategy;

        public PointBuilder(IPointFactory pointFactory, IPointCalculateStrategy simpleCalculateStrategy)
        {
            _pointFactory = pointFactory;
            _simpleCalculateStrategy = simpleCalculateStrategy;
        }

        public IPoint BuildExistingPoint(int eid, PointValue value, List<IPointEquation> equations)
        {
            return _pointFactory.Create(eid, value);
        }
    }
}
