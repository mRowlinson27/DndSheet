using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.DataPoint;
using DataManipulation.DataPoint;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    class DataPointClientTests
    {
        private DataPointClient _dataPointClient;
        private IDataPoint _dataPoint;
        private IDataPoint _dataPointServer;

        [SetUp]
        public void Setup()
        {
            _dataPoint = A.Fake<IDataPoint>();
            _dataPointServer = A.Fake<IDataPoint>();
        }

        [Test]
        public void Output_IsInitialValue()
        {
            var value = "test";

            _dataPointClient = new DataPointClient(_dataPoint, value);

            _dataPointClient.Output.Should().Be(value);
        }

        [Test]
        public void SubscribeTo_ChangeWrongType_ThrowsException()
        {
            var value = "test";
            var change = 1;
            _dataPointClient = new DataPointClient(_dataPoint, value);

            Assert.That(() => _dataPointClient.SubscribeTo(_dataPointServer, change),
                Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void SubscribeTo_ChangeString_OverwritesOutput()
        {
            var original = "old";
            var change = "new";
            _dataPointClient = new DataPointClient(_dataPoint, original);

            _dataPointClient.SubscribeTo(_dataPointServer, change);

            _dataPointClient.Output.Should().Be(change);
        }

        [Test]
        public void SubscribeTo_ChangeInt_AddsValue()
        {
            var original = 1;
            var change = 2;
            _dataPointClient = new DataPointClient(_dataPoint, original);

            _dataPointClient.SubscribeTo(_dataPointServer, change);

            _dataPointClient.Output.Should().Be(original + change);
        }

        [Test]
        public void SubscribeTo_MultipleInt_AddsAllValue()
        {
            var original = 1;
            var change1 = 2;
            var change2 = 123;
            var eid2 = 2;
            var dataPointServer2 = A.Fake<IDataPoint>();
            A.CallTo(() => dataPointServer2.Eid).Returns(eid2);
            _dataPointClient = new DataPointClient(_dataPoint, original);

            _dataPointClient.SubscribeTo(_dataPointServer, change1);
            _dataPointClient.SubscribeTo(dataPointServer2, change2);

            _dataPointClient.Output.Should().Be(original + change1 + change2);
        }

        [Test]
        public void SubscribeTo_StringTwice_ThrowsException()
        {
            var original = "old";
            var change = "new";
            var eid2 = 2;
            var dataPointServer2 = A.Fake<IDataPoint>();
            A.CallTo(() => dataPointServer2.Eid).Returns(eid2);
            _dataPointClient = new DataPointClient(_dataPoint, original);
            
            _dataPointClient.SubscribeTo(_dataPointServer, change);

            Assert.That(() => _dataPointClient.SubscribeTo(dataPointServer2, change),
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
            A.CallTo(() => _dataPoint.Eid).Returns(eid);
            A.CallTo(() => _dataPointServer.Eid).Returns(eidServer);

            var updates = new Dictionary<int, object> {{eid, update}};
            _dataPointClient = new DataPointClient(_dataPoint, original);

            _dataPointClient.SubscribeTo(_dataPointServer, change);
            _dataPointServer.Update += Raise.With(_dataPointServer, new UpdateArgs() {Updates = updates });

            _dataPointClient.Output.Should().Be(update);
        }

        [Test]
        public void UnSubscribe_OutputChangedBack()
        {
            var original = "old";
            var change = "new";
            _dataPointClient = new DataPointClient(_dataPoint, original);

            _dataPointClient.SubscribeTo(_dataPointServer, change);
            _dataPointClient.UnSubscribeTo(_dataPointServer);

            _dataPointClient.Output.Should().Be(original);
        }

        [Test]
        public void UnSubscribe_OutputUpdateDoesNotOccur()
        {
            var original = "old";
            var change = "new";
            var update = "update";
            var eid = 1;
            var eidServer = 2;
            A.CallTo(() => _dataPoint.Eid).Returns(eid);
            A.CallTo(() => _dataPointServer.Eid).Returns(eidServer);

            var updates = new Dictionary<int, object> { { eid, update } };
            _dataPointClient = new DataPointClient(_dataPoint, original);

            _dataPointClient.SubscribeTo(_dataPointServer, change);
            _dataPointClient.UnSubscribeTo(_dataPointServer);
            _dataPointServer.Update += Raise.With(_dataPointServer, new UpdateArgs() { Updates = updates });

            _dataPointClient.Output.Should().Be(original);
        }
    }
}
