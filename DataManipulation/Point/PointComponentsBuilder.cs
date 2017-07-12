using DataManipulation.API.Point;

namespace DataManipulation.Point
{
    public class PointComponentsBuilder : IPointComponentsBuilder
    {
        private readonly object _value;
        private readonly IPointClientFactory _pointClientFactory;
        private readonly IPointServerFactory _pointServerFactory;
        private readonly IPointCalculateStrategy _pointCalculateStrategy;

        public PointComponentsBuilder(object value, IPointClientFactory pointClientFactory, IPointServerFactory pointServerFactory, IPointCalculateStrategy pointCalculateStrategy)
        {
            _value = value;
            _pointClientFactory = pointClientFactory;
            _pointServerFactory = pointServerFactory;
            _pointCalculateStrategy = pointCalculateStrategy;
        }

        public IPointClient CreateClient(IPoint point)
        {
            return _pointClientFactory.Create(point, _value);
        }

        public IPointServer CreateServer(IPoint point)
        {
            return _pointServerFactory.Create(point, _pointCalculateStrategy);
        }
    }
}
