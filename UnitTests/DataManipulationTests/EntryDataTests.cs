using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API;
using DataManipulation.API.EntryData;
using DataManipulation.EntryData;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    public class EntryDataTests
    {
        private IEntryDataClientFactory _entryDataClientFactory;
        private IEntryDataServerFactory _entryDataServerFactory;
        private IEntryDataClient _entryDataClient;
        private IEntryDataServer _entryDataServer;

        [SetUp]
        public void Setup()
        {
            _entryDataClientFactory = A.Fake<IEntryDataClientFactory>();
            _entryDataServerFactory = A.Fake<IEntryDataServerFactory>();
            _entryDataClient = A.Fake<IEntryDataClient>();
            _entryDataServer = A.Fake<IEntryDataServer>();
            A.CallTo(() => _entryDataClientFactory.Create(A<IEntryData>.Ignored, A<object>.Ignored))
                .Returns(_entryDataClient);
            A.CallTo(() => _entryDataServerFactory.Create(A<IEntryData>.Ignored)).Returns(_entryDataServer);
        }

        [Test]
        public void Constructor_CreatesServerAndClient()
        {
            var entryData = new EntryData(1, null, _entryDataClientFactory, _entryDataServerFactory);

            A.CallTo(() => _entryDataClientFactory.Create(entryData, null)).MustHaveHappened();
            A.CallTo(() => _entryDataServerFactory.Create(entryData)).MustHaveHappened();
        }

        [Test]
        public void AddSubscriber_CallsServerMethod()
        {
            var change = 1;
            var entryData = new EntryData(1, null, _entryDataClientFactory, _entryDataServerFactory);
            var fakeEntryData = A.Fake<IEntryData>();

            entryData.AddSubscriber(fakeEntryData, change);

            A.CallTo(() => _entryDataServer.AddSubscriber(fakeEntryData, change)).MustHaveHappened();
        }

        [Test]
        public void SubscribeTo_CallsClientMethod()
        {
            var change = 1;
            var entryData = new EntryData(1, null, _entryDataClientFactory, _entryDataServerFactory);
            var fakeEntryData = A.Fake<IEntryData>();

            entryData.SubscribeTo(fakeEntryData, change);

            A.CallTo(() => _entryDataClient.SubscribeTo(fakeEntryData, change)).MustHaveHappened();
        }

        [Test]
        public void UnSubscribeTo_CallsClientMethod()
        {
            var change = 1;
            var entryData = new EntryData(1, null, _entryDataClientFactory, _entryDataServerFactory);
            var fakeEntryData = A.Fake<IEntryData>();

            entryData.UnSubscribeTo(fakeEntryData);

            A.CallTo(() => _entryDataClient.UnSubscribeTo(fakeEntryData)).MustHaveHappened();
        }
    }
}
