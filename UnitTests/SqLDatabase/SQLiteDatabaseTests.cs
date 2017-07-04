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
        private ISqLiteDatabase _sqLiteDatabase;
        private ISqLiteConnectionWrapper _sqLiteConnectionWrapper;

        [SetUp]
        public void Setup()
        {
            _sqLiteConnectionWrapper = A.Fake<ISqLiteConnectionWrapper>();
            _sqLiteDatabase = new SqLiteDatabase(_sqLiteConnectionWrapper);
        }

        [Test]
        public void Connect_CorrectCalls()
        {
            const string connection = "connect";

            _sqLiteDatabase.Connect(connection);

            A.CallTo(() => _sqLiteConnectionWrapper.Connect(connection)).MustHaveHappened();
        }

        [Test]
        public void CreateDatabase_CorrectCalls()
        {
            const string database = "data";

            _sqLiteDatabase.CreateNewDatabase(database);

            A.CallTo(() => _sqLiteConnectionWrapper.CreateFile(database)).MustHaveHappened();
        }

        [Test]
        public void ExecuteNonQuery_CorrectCalls()
        {
            const string sql = "sql";
            const string connection = "connect";
            _sqLiteDatabase.Connect(connection);

            _sqLiteDatabase.ExecuteNonQuery(sql);

            A.CallTo(() => _sqLiteConnectionWrapper.ExecuteNonQuery(sql)).MustHaveHappened();
        }

        [Test]
        public void ExecuteReader_CorrectCalls()
        {
            const string sql = "sql";
            const string connection = "connect";
            _sqLiteDatabase.Connect(connection);

            _sqLiteDatabase.ExecuteReader(sql);

            A.CallTo(() => _sqLiteConnectionWrapper.ExecuteReader(sql)).MustHaveHappened();
        }

        [Test]
        public void ExecuteReader_DataTransformedCorrectly()
        {
            const string sql = "sql";
            const string connection = "connect";
            var nameValueCollection = new NameValueCollection()
            {
                {"red", "rojo"},
                {"green", "verde"}
            };
            var sqLiteDataReaderWrapper = A.Fake<ISqLiteDataReaderWrapper>();

            A.CallTo(() => _sqLiteConnectionWrapper.ExecuteReader(sql)).Returns(sqLiteDataReaderWrapper);
            A.CallTo(() => sqLiteDataReaderWrapper.Read()).ReturnsNextFromSequence(true, true, false);
            A.CallTo(() => sqLiteDataReaderWrapper.GetValues()).Returns(nameValueCollection);

            _sqLiteDatabase.Connect(connection);

            var data = _sqLiteDatabase.ExecuteReader(sql);

            A.CallTo(() => _sqLiteConnectionWrapper.ExecuteReader(sql)).MustHaveHappened();
            data.Should().BeEquivalentTo(new List<NameValueCollection>() {nameValueCollection, nameValueCollection});
        }
    }
}
