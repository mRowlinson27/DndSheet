using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.Point;
using DataManipulation.Point;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    class PointClientTests
    {
        private PointClient _pointClient;
        private IPoint _point;
        private IPoint _pointServer;

        [SetUp]
        public void Setup()
        {
            _point = A.Fake<IPoint>();
            _pointServer = A.Fake<IPoint>();
        }

        [Test]
        public void Output_IsInitialValue()
        {
            var value = "test";

            _pointClient = new PointClient(_point, value);

            _pointClient.Output.Should().Be(value);
        }

        [Test]
        public void SubscribeTo_ChangeWrongType_ThrowsException()
        {
            var value = "test";
            var change = 1;
            _pointClient = new PointClient(_point, value);

            Assert.That(() => _pointClient.SubscribeTo(_pointServer, change),
                Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void SubscribeTo_ChangeString_OverwritesOutput()
        {
            var original = "old";
            var change = "new";
            _pointClient = new PointClient(_point, original);

            _pointClient.SubscribeTo(_pointServer, change);

            _pointClient.Output.Should().Be(change);
        }

        [Test]
        public void SubscribeTo_ChangeInt_AddsValue()
        {
            var original = 1;
            var change = 2;
            _pointClient = new PointClient(_point, original);

            _pointClient.SubscribeTo(_pointServer, change);

            _pointClient.Output.Should().Be(original + change);
        }

        [Test]
        public void SubscribeTo_MultipleInt_AddsAllValue()
        {
            var original = 1;
            var change1 = 2;
            var change2 = 123;
            var eid2 = 2;
            var pointServer2 = A.Fake<IPoint>();
            A.CallTo(() => pointServer2.Eid).Returns(eid2);
            _pointClient = new PointClient(_point, original);

            _pointClient.SubscribeTo(_pointServer, change1);
            _pointClient.SubscribeTo(pointServer2, change2);

            _pointClient.Output.Should().Be(original + change1 + change2);
        }

        [Test]
        public void SubscribeTo_StringTwice_ThrowsException()
        {
            var original = "old";
            var change = "new";
            var eid2 = 2;
            var pointServer2 = A.Fake<IPoint>();
            A.CallTo(() => pointServer2.Eid).Returns(eid2);
            _pointClient = new PointClient(_point, original);
            
            _pointClient.SubscribeTo(_pointServer, change);

            Assert.That(() => _pointClient.SubscribeTo(pointServer2, change),
                Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void SubscribedUpdate_UpdatesSubscriberOutput()
        {
            var original = "old";
            var change = "new";
            var update = "update";
            var eid = 1;
            var eidServer = 2;
            A.CallTo(() => _point.Eid).Returns(eid);
            A.CallTo(() => _pointServer.Eid).Returns(eidServer);

            var updates = new Dictionary<int, object> {{eid, update}};
            _pointClient = new PointClient(_point, original);

            _pointClient.SubscribeTo(_pointServer, change);
            _pointServer.Update += Raise.With(_pointServer, new UpdateArgs() {Updates = updates });

            _pointClient.Output.Should().Be(update);
        }

        [Test]
        public void UnSubscribe_OutputChangedBack()
        {
            var original = "old";
            var change = "new";
            _pointClient = new PointClient(_point, original);

            _pointClient.SubscribeTo(_pointServer, change);
            _pointClient.UnSubscribeTo(_pointServer);

            _pointClient.Output.Should().Be(original);
        }

        [Test]
        public void UnSubscribe_OutputUpdateDoesNotOccur()
        {
            var original = "old";
            var change = "new";
            var update = "update";
            var eid = 1;
            var eidServer = 2;
            A.CallTo(() => _point.Eid).Returns(eid);
            A.CallTo(() => _pointServer.Eid).Returns(eidServer);

            var updates = new Dictionary<int, object> { { eid, update } };
            _pointClient = new PointClient(_point, original);

            _pointClient.SubscribeTo(_pointServer, change);
            _pointClient.UnSubscribeTo(_pointServer);
            _pointServer.Update += Raise.With(_pointServer, new UpdateArgs() { Updates = updates });

            _pointClient.Output.Should().Be(original);
        }
    }
}
