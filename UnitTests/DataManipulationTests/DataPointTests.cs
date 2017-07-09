using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API;
using DataManipulation.API.DataPoint;
using DataManipulation.DataPoint;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    public class DataPointTests
    {
        private IDataPointComponentsBuilder _componentsBuilder;
        private IDataPointClient _dataPointClient;
        private IDataPointServer _dataPointServer;

        [SetUp]
        public void Setup()
        {
            _componentsBuilder = A.Fake<IDataPointComponentsBuilder>();
            _dataPointClient = A.Fake<IDataPointClient>();
            _dataPointServer = A.Fake<IDataPointServer>();
            A.CallTo(() => _componentsBuilder.CreateClient(A<IDataPoint>.Ignored))
                .Returns(_dataPointClient);
            A.CallTo(() => _componentsBuilder.CreateServer(A<IDataPoint>.Ignored)).Returns(_dataPointServer);
        }

        [Test]
        public void Constructor_CreatesServerAndClient()
        {
            var dataPoint = new DataPoint(1, _componentsBuilder);

            A.CallTo(() => _componentsBuilder.CreateClient(dataPoint)).MustHaveHappened();
            A.CallTo(() => _componentsBuilder.CreateServer(dataPoint)).MustHaveHappened();
        }

        [Test]
        public void AddSubscriber_CallsServerMethod()
        {
            var change = 1;
            var dataPoint = new DataPoint(1, _componentsBuilder);
            var fakeDataPoint = A.Fake<IDataPoint>();

            dataPoint.AddSubscriber(fakeDataPoint, change);

            A.CallTo(() => _dataPointServer.AddSubscriber(fakeDataPoint, change)).MustHaveHappened();
        }

        [Test]
        public void SubscribeTo_CallsClientMethod()
        {
            var change = 1;
            var dataPoint = new DataPoint(1, _componentsBuilder);
            var fakeDataPoint = A.Fake<IDataPoint>();

            dataPoint.SubscribeTo(fakeDataPoint, change);

            A.CallTo(() => _dataPointClient.SubscribeTo(fakeDataPoint, change)).MustHaveHappened();
        }

        [Test]
        public void UnSubscribeTo_CallsClientMethod()
        {
            var dataPoint = new DataPoint(1, _componentsBuilder);
            var fakeDataPoint = A.Fake<IDataPoint>();

            dataPoint.UnSubscribeTo(fakeDataPoint);

            A.CallTo(() => _dataPointClient.UnSubscribeTo(fakeDataPoint)).MustHaveHappened();
        }

        [Test]
        public void UpdateSubscription_CallsServerMethod()
        {
            var newChange = 1;
            var eid = 1;
            var dataPoint = new DataPoint(1, _componentsBuilder);
            var updateArgs = new UpdateArgs();
            A.CallTo(() => _dataPointServer.UpdateSubscription(eid, newChange)).Returns(updateArgs);
            dataPoint.MonitorEvents();

            dataPoint.UpdateSubscription(eid, newChange);

            A.CallTo(() => _dataPointServer.UpdateSubscription(eid, newChange)).MustHaveHappened();
            dataPoint.ShouldRaise("Update").WithArgs<UpdateArgs>(args => args == updateArgs);
        }

        [Test]
        public void UpdateSubscriptions_CallsServerMethod()
        {
            var newChange = new List<object> {1, 2};
            var eid = new List<int> { 1, 2 };
            var dataPoint = new DataPoint(1, _componentsBuilder);
            var updateArgs = new UpdateArgs();
            A.CallTo(() => _dataPointServer.UpdateSubscriptions(eid, newChange)).Returns(updateArgs);
            dataPoint.MonitorEvents();

            dataPoint.UpdateSubscriptions(eid, newChange);

            A.CallTo(() => _dataPointServer.UpdateSubscriptions(eid, newChange)).MustHaveHappened();
            dataPoint.ShouldRaise("Update").WithArgs<UpdateArgs>(args => args == updateArgs);
        }
    }
}
