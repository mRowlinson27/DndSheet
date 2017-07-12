using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.Point;
using DataManipulation.Point;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    public class PointServerTests
    {
        private PointServer _pointServer;
        private IPointCalculateStrategy _pointCalculateStrategy;
        private IPoint _pointClient;
        private IPoint _point;

        [SetUp]
        public void Setup()
        {
            _point = A.Fake<IPoint>();
            _pointClient = A.Fake<IPoint>();
            _pointCalculateStrategy = A.Fake<IPointCalculateStrategy>();
            _pointServer = new PointServer(_point, _pointCalculateStrategy);
        }

        [Test]
        public void AddSubscriber_SameEid_ThrowsException()
        {
            A.CallTo(() => _point.Eid).Returns(1);
            A.CallTo(() => _pointClient.Eid).Returns(1);

            Assert.That(() => _pointServer.AddSubscriber(_pointClient, null),
                Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void AddSubscriber_OtherSubscribes()
        {
            var change = "string";
            A.CallTo(() => _point.Eid).Returns(1);
            A.CallTo(() => _pointClient.Eid).Returns(2);
            A.CallTo(() => _pointCalculateStrategy.Calculate(change)).Returns(change);

            _pointServer.AddSubscriber(_pointClient, change);

            A.CallTo(() => _pointClient.SubscribeTo(_point, change)).MustHaveHappened();
            A.CallTo(() => _pointCalculateStrategy.Calculate(change)).MustHaveHappened();
        }
    }
}
