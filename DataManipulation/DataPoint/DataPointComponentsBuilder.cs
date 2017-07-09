using DataManipulation.API.DataPoint;

namespace DataManipulation.DataPoint
{
    public class DataPointComponentsBuilder : IDataPointComponentsBuilder
    {
        private readonly object _value;
        private readonly IDataPointClientFactory _dataPointClientFactory;
        private readonly IDataPointServerFactory _dataPointServerFactory;
        private readonly IDataPointCalculateStrategy _dataPointCalculateStrategy;

        public DataPointComponentsBuilder(object value, IDataPointClientFactory dataPointClientFactory, IDataPointServerFactory dataPointServerFactory, IDataPointCalculateStrategy dataPointCalculateStrategy)
        {
            _value = value;
            _dataPointClientFactory = dataPointClientFactory;
            _dataPointServerFactory = dataPointServerFactory;
            _dataPointCalculateStrategy = dataPointCalculateStrategy;
        }

        public IDataPointClient CreateClient(IDataPoint dataPoint)
        {
            return _dataPointClientFactory.Create(dataPoint, _value);
        }

        public IDataPointServer CreateServer(IDataPoint dataPoint)
        {
            return _dataPointServerFactory.Create(dataPoint, _dataPointCalculateStrategy);
        }
    }
}
