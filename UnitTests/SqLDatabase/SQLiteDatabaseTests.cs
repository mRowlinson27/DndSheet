using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SQLite;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using SqlDatabase;
using SqlDatabase.API;
using SqlDatabase.Implementation;
using SqlDatabase.Interfaces;

namespace UnitTests.SqLDatabase
{
    [TestFixture]
    public class SqLiteDatabaseTests
    {
        private string _connection;
        private ISqLiteDatabase _sqLiteDatabase;
        private ISqLiteConnectionWrapper _sqLiteConnectionWrapper;
        private ISqLiteConnectionWrapperFactory _sqLiteConnectionWrapperFactory;

        [SetUp]
        public void Setup()
        {
            _connection = "connection";
            _sqLiteConnectionWrapperFactory = A.Fake<ISqLiteConnectionWrapperFactory>();
            _sqLiteConnectionWrapper = A.Fake<ISqLiteConnectionWrapper>();
            _sqLiteDatabase = new SqLiteDatabase(_connection, _sqLiteConnectionWrapperFactory);
        }

        [Test]
        public void ExecuteNonQuery_CorrectCalls()
        {
            const string sql = "sql";

            A.CallTo(() => _sqLiteConnectionWrapperFactory.Create("Data Source=" + _connection)).Returns(_sqLiteConnectionWrapper);

            _sqLiteDatabase.ExecuteNonQuery(sql);

            A.CallTo(() => _sqLiteConnectionWrapper.Open()).MustHaveHappened().
                Then(A.CallTo(() => _sqLiteConnectionWrapper.ExecuteNonQuery(sql)).MustHaveHappened()).
                Then(A.CallTo(() => _sqLiteConnectionWrapper.Close()).MustHaveHappened()).
                Then(A.CallTo(() => _sqLiteConnectionWrapper.Dispose()).MustHaveHappened());
        }

        [Test]
        public void ExecuteReader_CorrectCalls()
        {
            const string sql = "sql";

            A.CallTo(() => _sqLiteConnectionWrapperFactory.Create("Data Source=" + _connection)).Returns(_sqLiteConnectionWrapper);

            _sqLiteDatabase.ExecuteReader(sql);

            A.CallTo(() => _sqLiteConnectionWrapper.Open()).MustHaveHappened().
                Then(A.CallTo(() => _sqLiteConnectionWrapper.ExecuteReader(sql)).MustHaveHappened()).
                Then(A.CallTo(() => _sqLiteConnectionWrapper.Close()).MustHaveHappened()).
                Then(A.CallTo(() => _sqLiteConnectionWrapper.Dispose()).MustHaveHappened());
        }

        [Test]
        public void ExecuteReader_DataTransformedCorrectly()
        {
            const string sql = "sql";
            var nameValueCollection = new NameValueCollection()
            {
                {"red", "rojo"},
                {"green", "verde"}
            };
            var sqLiteDataReaderWrapper = A.Fake<ISqLiteDataReaderWrapper>();
            A.CallTo(() => _sqLiteConnectionWrapperFactory.Create("Data Source=" + _connection)).Returns(_sqLiteConnectionWrapper);

            A.CallTo(() => _sqLiteConnectionWrapper.ExecuteReader(sql)).Returns(sqLiteDataReaderWrapper);
            A.CallTo(() => sqLiteDataReaderWrapper.Read()).ReturnsNextFromSequence(true, true, false);
            A.CallTo(() => sqLiteDataReaderWrapper.GetValues()).Returns(nameValueCollection);

            var data = _sqLiteDatabase.ExecuteReader(sql);

            data.Should().BeEquivalentTo(new List<NameValueCollection>() {nameValueCollection, nameValueCollection});
        }
    }
}
