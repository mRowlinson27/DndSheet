using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.EntryData;
using DataManipulation.EntryData;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    class EntryDataClientTests
    {
        private EntryDataClient _entryDataClient;
        private IEntryData _entryData;
        private IEntryData _entryDataServer;

        [SetUp]
        public void Setup()
        {
            _entryData = A.Fake<IEntryData>();
            _entryDataServer = A.Fake<IEntryData>();
        }

        [Test]
        public void Output_IsInitialValue()
        {
            var value = "test";

            var entryDataClient = new EntryDataClient(_entryData, value);

            entryDataClient.Output.Should().Be(value);
        }

        [Test]
        public void SubscribeTo_ChangeWrongType_ThrowsException()
        {
            var value = "test";
            var change = 1;
            var entryDataClient = new EntryDataClient(_entryData, value);

            Assert.That(() => entryDataClient.SubscribeTo(_entryDataServer, change),
                Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void SubscribeTo_ChangeString_OverwritesOutput()
        {
            var original = "old";
            var change = "new";
            var entryDataClient = new EntryDataClient(_entryData, original);

            entryDataClient.SubscribeTo(_entryDataServer, change);

            entryDataClient.Output.Should().Be(change);
        }

        [Test]
        public void SubscribedUpdate_UpdatesSubscriberOutput()
        {
            true.Should().BeFalse();
        }

        [Test]
        public void UnSubscribe_OutputChangedBack()
        {
            true.Should().BeFalse();
        }
    }
}
