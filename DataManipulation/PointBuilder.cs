using System.Collections.Generic;
using DataManipulation.DTO;
using DataManipulation.Interfaces;

namespace DataManipulation
{
    public class PointBuilder : IPointBuilder
    {
        private readonly IPointFactory _pointFactory;
        private readonly IEquationCalculateStrategy _simpleCalculateStrategy;

        public PointBuilder(IPointFactory pointFactory, IEquationCalculateStrategy simpleCalculateStrategy)
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
