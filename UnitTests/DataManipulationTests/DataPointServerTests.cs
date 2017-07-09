using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.DataPoint;
using DataManipulation.DataPoint;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    public class DataPointServerTests
    {
        private DataPointServer _dataPointServer;
        private IDataPointCalculateStrategy _dataPointCalculateStrategy;
        private IDataPoint _dataPointClient;
        private IDataPoint _dataPoint;

        [SetUp]
        public void Setup()
        {
            _dataPoint = A.Fake<IDataPoint>();
            _dataPointClient = A.Fake<IDataPoint>();
            _dataPointCalculateStrategy = A.Fake<IDataPointCalculateStrategy>();
            _dataPointServer = new DataPointServer(_dataPoint, _dataPointCalculateStrategy);
        }

        [Test]
        public void AddSubscriber_SameEid_ThrowsException()
        {
            A.CallTo(() => _dataPoint.Eid).Returns(1);
            A.CallTo(() => _dataPointClient.Eid).Returns(1);

            Assert.That(() => _dataPointServer.AddSubscriber(_dataPointClient, null),
                Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void AddSubscriber_OtherSubscribes()
        {
            var change = "string";
            A.CallTo(() => _dataPoint.Eid).Returns(1);
            A.CallTo(() => _dataPointClient.Eid).Returns(2);
            A.CallTo(() => _dataPointCalculateStrategy.Calculate(change)).Returns(change);

            _dataPointServer.AddSubscriber(_dataPointClient, change);

            A.CallTo(() => _dataPointClient.SubscribeTo(_dataPoint, change)).MustHaveHappened();
            A.CallTo(() => _dataPointCalculateStrategy.Calculate(change)).MustHaveHappened();
        }
    }
}
