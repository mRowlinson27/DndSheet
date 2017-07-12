using DataManipulation.API.Point;
using SqlDatabase.API.DTO;

namespace DataManipulation.Point
{
    public class PointBuilder : IPointBuilder
    {
        private readonly IPointFactory _pointFactory;
        private IPointComponentsBuilderFactory _pointComponentsBuilderFactory;
        private readonly IPointClientFactory _pointClientFactory;
        private readonly IPointServerFactory _pointServerFactory;
        private readonly IPointCalculateStrategy _simpleCalculateStrategy;

        public PointBuilder(IPointFactory pointFactory,
            IPointComponentsBuilderFactory pointComponentsBuilderFactory,
            IPointClientFactory pointClientFactory, IPointServerFactory pointServerFactory,
            IPointCalculateStrategy simpleCalculateStrategy)
        {
            _pointFactory = pointFactory;
            _pointComponentsBuilderFactory = pointComponentsBuilderFactory;
            _pointClientFactory = pointClientFactory;
            _pointServerFactory = pointServerFactory;
            _simpleCalculateStrategy = simpleCalculateStrategy;
        }

        public IPoint BuildPoint(TableEntity tableEntity)
        {
            var pointComponentsBuilder = _pointComponentsBuilderFactory.Create(tableEntity.Value,
                _pointClientFactory, _pointServerFactory, _simpleCalculateStrategy);
            return _pointFactory.Create(tableEntity.Eid, pointComponentsBuilder);
        }
    }
}
