using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.DataPoint;
using DataManipulation.DataPoint;
using FakeItEasy;
using NUnit.Framework;
using SqlDatabase.API.DTO;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    public class DataPointBuilderTests
    {
        private DataPointBuilder _dataPointBuilder;
        private IDataPointFactory _dataPointFactory;
        private IDataPointComponentsBuilderFactory _dataPointComponentsBuilderFactory;
        private IDataPointComponentsBuilder _dataPointComponentsBuilder;
        private IDataPointClientFactory _dataPointClientFactory;
        private IDataPointServerFactory _dataPointServerFactory;
        private IDataPointCalculateStrategy _simpleCalculateStrategy;

        [SetUp]
        public void Setup()
        {
            _dataPointComponentsBuilder = A.Fake<IDataPointComponentsBuilder>();
            _dataPointFactory = A.Fake<IDataPointFactory>();
            _dataPointComponentsBuilderFactory = A.Fake<IDataPointComponentsBuilderFactory>();
            _dataPointClientFactory = A.Fake<IDataPointClientFactory>();
            _dataPointServerFactory = A.Fake<IDataPointServerFactory>();
            _simpleCalculateStrategy = A.Fake<IDataPointCalculateStrategy>();
            _dataPointBuilder = new DataPointBuilder(_dataPointFactory, _dataPointComponentsBuilderFactory,
                _dataPointClientFactory, _dataPointServerFactory, _simpleCalculateStrategy);
        }

        [Test]
        public void Build_RegularPoint()
        {
            var tableEntity = new TableEntity
            {
                Eid = 1,
                DataType = "String",
                Value = "Hi"
            };

            A.CallTo(() => _dataPointComponentsBuilderFactory.Create(tableEntity.Value,
                    _dataPointClientFactory, _dataPointServerFactory, _simpleCalculateStrategy))
                .Returns(_dataPointComponentsBuilder);

            _dataPointBuilder.BuildPoint(tableEntity);

            A.CallTo(() => _dataPointComponentsBuilderFactory.Create(tableEntity.Value,
                _dataPointClientFactory, _dataPointServerFactory, _simpleCalculateStrategy)).MustHaveHappened();
            A.CallTo(() => _dataPointFactory.Create(tableEntity.Eid, _dataPointComponentsBuilder));
        }
    }
}
