using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API;
using DataManipulation.API.Point;
using DataManipulation.Point;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    public class PointTests
    {
        private IPointComponentsBuilder _componentsBuilder;
        private IPointClient _pointClient;
        private IPointServer _pointServer;

        [SetUp]
        public void Setup()
        {
            _componentsBuilder = A.Fake<IPointComponentsBuilder>();
            _pointClient = A.Fake<IPointClient>();
            _pointServer = A.Fake<IPointServer>();
            A.CallTo(() => _componentsBuilder.CreateClient(A<IPoint>.Ignored))
                .Returns(_pointClient);
            A.CallTo(() => _componentsBuilder.CreateServer(A<IPoint>.Ignored)).Returns(_pointServer);
        }

        [Test]
        public void Constructor_CreatesServerAndClient()
        {
            var point = new Point(1, _componentsBuilder);

            A.CallTo(() => _componentsBuilder.CreateClient(point)).MustHaveHappened();
            A.CallTo(() => _componentsBuilder.CreateServer(point)).MustHaveHappened();
        }

        [Test]
        public void AddSubscriber_CallsServerMethod()
        {
            var change = 1;
            var point = new Point(1, _componentsBuilder);
            var fakePoint = A.Fake<IPoint>();

            point.AddSubscriber(fakePoint, change);

            A.CallTo(() => _pointServer.AddSubscriber(fakePoint, change)).MustHaveHappened();
        }

        [Test]
        public void SubscribeTo_CallsClientMethod()
        {
            var change = 1;
            var point = new Point(1, _componentsBuilder);
            var fakePoint = A.Fake<IPoint>();

            point.SubscribeTo(fakePoint, change);

            A.CallTo(() => _pointClient.SubscribeTo(fakePoint, change)).MustHaveHappened();
        }

        [Test]
        public void UnSubscribeTo_CallsClientMethod()
        {
            var point = new Point(1, _componentsBuilder);
            var fakePoint = A.Fake<IPoint>();

            point.UnSubscribeTo(fakePoint);

            A.CallTo(() => _pointClient.UnSubscribeTo(fakePoint)).MustHaveHappened();
        }

        [Test]
        public void UpdateSubscription_CallsServerMethod()
        {
            var newChange = 1;
            var eid = 1;
            var point = new Point(1, _componentsBuilder);
            var updateArgs = new UpdateArgs();
            A.CallTo(() => _pointServer.UpdateSubscription(eid, newChange)).Returns(updateArgs);
            point.MonitorEvents();

            point.UpdateSubscription(eid, newChange);

            A.CallTo(() => _pointServer.UpdateSubscription(eid, newChange)).MustHaveHappened();
            point.ShouldRaise("Update").WithArgs<UpdateArgs>(args => args == updateArgs);
        }

        [Test]
        public void UpdateSubscriptions_CallsServerMethod()
        {
            var newChange = new List<object> {1, 2};
            var eid = new List<int> { 1, 2 };
            var point = new Point(1, _componentsBuilder);
            var updateArgs = new UpdateArgs();
            A.CallTo(() => _pointServer.UpdateSubscriptions(eid, newChange)).Returns(updateArgs);
            point.MonitorEvents();

            point.UpdateSubscriptions(eid, newChange);

            A.CallTo(() => _pointServer.UpdateSubscriptions(eid, newChange)).MustHaveHappened();
            point.ShouldRaise("Update").WithArgs<UpdateArgs>(args => args == updateArgs);
        }
    }
}
