using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.Point;
using DataManipulation.Point;
using FakeItEasy;
using NUnit.Framework;
using SqlDatabase.API.DTO;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    public class PointBuilderTests
    {
        private PointBuilder _pointBuilder;
        private IPointFactory _pointFactory;
        private IPointComponentsBuilderFactory _pointComponentsBuilderFactory;
        private IPointComponentsBuilder _pointComponentsBuilder;
        private IPointClientFactory _pointClientFactory;
        private IPointServerFactory _pointServerFactory;
        private IPointCalculateStrategy _simpleCalculateStrategy;

        [SetUp]
        public void Setup()
        {
            _pointComponentsBuilder = A.Fake<IPointComponentsBuilder>();
            _pointFactory = A.Fake<IPointFactory>();
            _pointComponentsBuilderFactory = A.Fake<IPointComponentsBuilderFactory>();
            _pointClientFactory = A.Fake<IPointClientFactory>();
            _pointServerFactory = A.Fake<IPointServerFactory>();
            _simpleCalculateStrategy = A.Fake<IPointCalculateStrategy>();
            _pointBuilder = new PointBuilder(_pointFactory, _pointComponentsBuilderFactory,
                _pointClientFactory, _pointServerFactory, _simpleCalculateStrategy);
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

            A.CallTo(() => _pointComponentsBuilderFactory.Create(tableEntity.Value,
                    _pointClientFactory, _pointServerFactory, _simpleCalculateStrategy))
                .Returns(_pointComponentsBuilder);

            _pointBuilder.BuildPoint(tableEntity);

            A.CallTo(() => _pointComponentsBuilderFactory.Create(tableEntity.Value,
                _pointClientFactory, _pointServerFactory, _simpleCalculateStrategy)).MustHaveHappened();
            A.CallTo(() => _pointFactory.Create(tableEntity.Eid, _pointComponentsBuilder));
        }
    }
}
