using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using SqlDatabase.API;
using SqlDatabase.Implementation;
using SqlDatabase.Interfaces;
using Utilities.API;

namespace UnitTests.SqLDatabase
{
    [TestFixture]
    public class EidCreatorTests
    {
        private EidCreator _eidCreator;
        private IDatabase _database;
        private IMostlyFullSequence _mostlyFullSequence;

        [SetUp]
        public void Setup()
        {
            _database = A.Fake<IDatabase>();
            _mostlyFullSequence = A.Fake<IMostlyFullSequence>();
            _eidCreator = new EidCreator(_database, _mostlyFullSequence);
        }

        [Test]
        public void OnDatabaseConnected_MakesCorrectCalls()
        {
            var eids = new List<int>() {1, 2};
            A.CallTo(() => _database.FindAllEids()).Returns(eids);

            _database.Connected += Raise.With(EventArgs.Empty);

            A.CallTo(() => _database.FindAllEids()).MustHaveHappened();
            A.CallTo(() => _mostlyFullSequence.Clear()).MustHaveHappened().
                Then(A.CallTo(() => _mostlyFullSequence.InsertMultiple(eids)).MustHaveHappened());
        }

        [Test]
        public void GetNextEid_MakesCorrectCalls()
        {
            var eid = 1;
            A.CallTo(() => _mostlyFullSequence.Add()).Returns(eid);

            var response = _eidCreator.GetNextEid();

            response.Should().Be(eid);
        }

        [Test]
        public void GetNextXEids_MakesCorrectCalls()
        {
            var eids = new List<int>() { 1, 2 };
            A.CallTo(() => _mostlyFullSequence.AddMultiple(2)).Returns(eids);

          var response = _eidCreator.GetNextXEids(2);

            response.Should().BeEquivalentTo(eids);
        }

        [Test]
        public void DeleteEidAt_MakesCorrectCalls()
        {
            var eid = 1;

            _eidCreator.DeleteEidAt(eid);

            A.CallTo(() => _mostlyFullSequence.DeleteAt(eid)).MustHaveHappened();
        }

        [Test]
        public void DeleteMultipleEidsAt_MakesCorrectCalls()
        {
            var eids = new List<int>() { 1, 2 };

            _eidCreator.DeleteMultipleEidsAt(eids);

            A.CallTo(() => _mostlyFullSequence.DeleteMultipleAt(eids)).MustHaveHappened();
        }
    }
}
