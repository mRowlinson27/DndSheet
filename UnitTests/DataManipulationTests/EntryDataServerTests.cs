using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.EntryData;
using DataManipulation.EntryData;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    public class EntryDataServerTests
    {
        private EntryDataServer _entryDataServer;
        private IEntryData _entryDataClient;
        private IEntryData _entryData;

        [SetUp]
        public void Setup()
        {
            _entryData = A.Fake<IEntryData>();
            _entryDataClient = A.Fake<IEntryData>();
            _entryDataServer = new EntryDataServer(_entryData);
        }

        [Test]
        public void AddSubscriber_SameEid_ThrowsException()
        {
            A.CallTo(() => _entryData.Eid).Returns(1);
            A.CallTo(() => _entryDataClient.Eid).Returns(1);

            Assert.That(() => _entryDataServer.AddSubscriber(_entryDataClient, null),
                Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void AddSubscriber_OtherSubscribes()
        {
            var change = "string";
            A.CallTo(() => _entryData.Eid).Returns(1);
            A.CallTo(() => _entryDataClient.Eid).Returns(2);

            _entryDataServer.AddSubscriber(_entryDataClient, change);

            A.CallTo(() => _entryDataClient.SubscribeTo(_entryData, change)).MustHaveHappened();
        }
    }
}
