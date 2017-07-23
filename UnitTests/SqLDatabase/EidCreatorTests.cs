using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;
using SqlDatabase.API;
using SqlDatabase.Implementation;
using SqlDatabase.Interfaces;

namespace UnitTests.SqLDatabase
{
    [TestFixture]
    public class EidCreatorTests
    {
        private EidCreator _eidCreator;
        private IDatabase _database;
        private ISqlQueryConstructor _sqlQueryConstructor;

        [SetUp]
        public void Setup()
        {
            _database = A.Fake<IDatabase>();
            _sqlQueryConstructor = A.Fake<ISqlQueryConstructor>();
            _eidCreator = new EidCreator(_database, _sqlQueryConstructor);
        }

        [Test]
        public void OnDatabaseConnected_MakesCorrectCalls()
        {
            _database.Connected += Raise.With(EventArgs.Empty);

            A.CallTo(() => _sqlQueryConstructor.FindAllEids()).MustHaveHappened();
        }
    }
}
