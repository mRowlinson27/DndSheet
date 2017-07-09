using DataManipulation.API.DataPoint;
using SqlDatabase.API.DTO;

namespace DataManipulation.DataPoint
{
    public class DataPointBuilder : IDataPointBuilder
    {
        private readonly IDataPointFactory _dataPointFactory;
        private IDataPointComponentsBuilderFactory _dataPointComponentsBuilderFactory;
        private readonly IDataPointClientFactory _dataPointClientFactory;
        private readonly IDataPointServerFactory _dataPointServerFactory;
        private readonly IDataPointCalculateStrategy _simpleCalculateStrategy;

        public DataPointBuilder(IDataPointFactory dataPointFactory,
            IDataPointComponentsBuilderFactory dataPointComponentsBuilderFactory,
            IDataPointClientFactory dataPointClientFactory, IDataPointServerFactory dataPointServerFactory,
            IDataPointCalculateStrategy simpleCalculateStrategy)
        {
            _dataPointFactory = dataPointFactory;
            _dataPointComponentsBuilderFactory = dataPointComponentsBuilderFactory;
            _dataPointClientFactory = dataPointClientFactory;
            _dataPointServerFactory = dataPointServerFactory;
            _simpleCalculateStrategy = simpleCalculateStrategy;
        }

        public IDataPoint BuildPoint(TableEntity tableEntity)
        {
            var dataPointComponentsBuilder = _dataPointComponentsBuilderFactory.Create(tableEntity.Value,
                _dataPointClientFactory, _dataPointServerFactory, _simpleCalculateStrategy);
            return _dataPointFactory.Create(tableEntity.Eid, dataPointComponentsBuilder);
        }
    }
}
