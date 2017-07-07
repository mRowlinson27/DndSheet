using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using SqlDatabase;
using SqlDatabase.API;
using SqlDatabase.API.DTO;
using SqlDatabase.Interfaces;

namespace UnitTests.SqLDatabase
{
    [TestFixture]
    public class DatabaseControlTests
    {
        private DatabaseControl _databaseControl;
        private ISqLiteDatabaseBuilder _databaseBuilder;
        private ISqlQueryConstructor _sqlQueryConstructor;
        private ISqLiteDatabase _sqLiteDatabase;

        [SetUp]
        public void Setup()
        {
            _databaseBuilder = A.Fake<ISqLiteDatabaseBuilder>();
            _sqlQueryConstructor = A.Fake<ISqlQueryConstructor>();
            _sqLiteDatabase = A.Fake<ISqLiteDatabase>();
            _databaseControl = new DatabaseControl(_databaseBuilder, _sqlQueryConstructor);
        }

        [Test]
        public void Connect_BuildsConnection()
        {
            const string path = @"C:\Temp\MYDATABASE.db";
            _databaseControl.Connect(path);

            A.CallTo(() => _databaseBuilder.Build(path)).MustHaveHappened();
        }

        [Test]
        public void InsertIntoEntites_GetsSqlAndExecutesAsNonQuery()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);

            _databaseControl.Connect(path);
            var data = new List<TableEntity>
            {
                new TableEntity()
            };

            A.CallTo(() => _sqlQueryConstructor.InsertIntoEntitiesQuery(data)).Returns(sql);

            _databaseControl.InsertIntoEntites(data);

            A.CallTo(() => _sqlQueryConstructor.InsertIntoEntitiesQuery(data)).MustHaveHappened();
            A.CallTo(() => _sqLiteDatabase.ExecuteNonQuery(sql)).MustHaveHappened();
        }

        [Test]
        public void InsertIntoPredicates_GetsSqlAndExecutesAsNonQuery()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);

            _databaseControl.Connect(path);
            var data = new List<Triple>
            {
                new Triple()
            };

            A.CallTo(() => _sqlQueryConstructor.InsertIntoPredicatesQuery(data)).Returns(sql);

            _databaseControl.InsertIntoPredicates(data);

            A.CallTo(() => _sqlQueryConstructor.InsertIntoPredicatesQuery(data)).MustHaveHappened();
            A.CallTo(() => _sqLiteDatabase.ExecuteNonQuery(sql)).MustHaveHappened();
        }

        [Test]
        public void FindEntitiesByEid_GetsSqlAndExecutesAsQuery()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);

            _databaseControl.Connect(path);
            var nameValueData = new List<NameValueCollection>
            {
                new NameValueCollection()
                {
                    {"Eid", "1"}, {"DataType", "String"}, {"Value", "Test"}
                }
            };

            A.CallTo(() => _sqlQueryConstructor.FindEntitiesByEidQuery(A<List<string>>.Ignored)).Returns(sql);
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).Returns(nameValueData);

            _databaseControl.FindEntitiesByEid(null);

            A.CallTo(() => _sqlQueryConstructor.FindEntitiesByEidQuery(null)).MustHaveHappened();
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).MustHaveHappened();
        }

        [Test]
        public void FindEntitiesByEid_ReturnsProperTableEntities()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);

            _databaseControl.Connect(path);
            var nameValueData = new List<NameValueCollection>
            {
                new NameValueCollection()
                {
                    {"Eid", "1"}, {"DataType", "String"}, {"Value", "Test"}
                }
            };
            var data = new List<TableEntity>
            {
                new TableEntity
                {
                    Eid = 1, DataType = "String", Value = "Test"
                }
            };

            A.CallTo(() => _sqlQueryConstructor.FindEntitiesByEidQuery(A<List<string>>.Ignored)).Returns(sql);
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).Returns(nameValueData);

            var response = _databaseControl.FindEntitiesByEid(null);

            response.ShouldAllBeEquivalentTo(data);
        }

        [Test]
        public void FindEntitiesByDataType_GetsSqlAndExecutesAsQuery()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);
            _databaseControl.Connect(path);
            var nameValueData = new List<NameValueCollection>
            {
                new NameValueCollection()
                {
                    {"Eid", "1"}, {"DataType", "String"}, {"Value", "Test"}
                }
            };
            A.CallTo(() => _sqlQueryConstructor.FindEntitiesByDataTypeQuery(A<string>.Ignored)).Returns(sql);
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).Returns(nameValueData);

            _databaseControl.FindEntitiesByDatatype(null);

            A.CallTo(() => _sqlQueryConstructor.FindEntitiesByDataTypeQuery(null)).MustHaveHappened();
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).MustHaveHappened();
        }

        [Test]
        public void FindEntitiesByDataType_ReturnsProperTableEntities()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);
            _databaseControl.Connect(path);
            var nameValueData = new List<NameValueCollection>
            {
                new NameValueCollection()
                {
                    {"Eid", "1"}, {"DataType", "String"}, {"Value", "Test"}
                }
            };
            var data = new List<TableEntity>
            {
                new TableEntity
                {
                    Eid = 1, DataType = "String", Value = "Test"
                }
            };
            A.CallTo(() => _sqlQueryConstructor.FindEntitiesByDataTypeQuery(A<string>.Ignored)).Returns(sql);
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).Returns(nameValueData);

            var response = _databaseControl.FindEntitiesByDatatype(null);

            response.ShouldAllBeEquivalentTo(data);
        }

        [Test]
        public void FindPredicatesAffectedBySubject_GetsSqlAndExecutesAsQuery()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);
            _databaseControl.Connect(path);
            var nameValueData = new List<NameValueCollection>
            {
                new NameValueCollection()
                {
                    {"Subject", "1"}, {"Relationship", "0"}, {"Object", "2"}
                }
            };
            A.CallTo(() => _sqlQueryConstructor.FindPredicatesAffectedBySubjectQuery(A<string>.Ignored)).Returns(sql);
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).Returns(nameValueData);

            _databaseControl.FindPredicatesAffectedBySubject(null);

            A.CallTo(() => _sqlQueryConstructor.FindPredicatesAffectedBySubjectQuery(null)).MustHaveHappened();
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).MustHaveHappened();
        }

        [Test]
        public void FindPredicatesAffectedBySubject_ReturnsProperTriples()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);
            _databaseControl.Connect(path);
            var nameValueData = new List<NameValueCollection>
            {
                new NameValueCollection()
                {
                    {"Subject", "1"}, {"Relationship", "0"}, {"Object", "2"}
                }
            };
            var data = new List<Triple>
            {
                new Triple
                {
                    Subject = "1", Relationship = "0", Object = "2"
                }
            };
            A.CallTo(() => _sqlQueryConstructor.FindPredicatesAffectedBySubjectQuery(A<string>.Ignored)).Returns(sql);
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).Returns(nameValueData);

            var response = _databaseControl.FindPredicatesAffectedBySubject(null);

            response.ShouldAllBeEquivalentTo(data);
        }

        [Test]
        public void FindPredicatesAffectingObject_GetsSqlAndExecutesAsQuery()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);
            _databaseControl.Connect(path);
            var nameValueData = new List<NameValueCollection>
            {
                new NameValueCollection()
                {
                    {"Subject", "1"}, {"Relationship", "0"}, {"Object", "2"}
                }
            };
            A.CallTo(() => _sqlQueryConstructor.FindPredicatesAffectingObjectQuery(A<string>.Ignored)).Returns(sql);
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).Returns(nameValueData);

            _databaseControl.FindPredicatesAffectingObject(null);

            A.CallTo(() => _sqlQueryConstructor.FindPredicatesAffectingObjectQuery(null)).MustHaveHappened();
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).MustHaveHappened();
        }

        [Test]
        public void FindPredicatesAffectingObject_ReturnsProperTriples()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);
            _databaseControl.Connect(path);
            var nameValueData = new List<NameValueCollection>
            {
                new NameValueCollection()
                {
                    {"Subject", "1"}, {"Relationship", "0"}, {"Object", "2"}
                }
            };
            var data = new List<Triple>
            {
                new Triple
                {
                    Subject = "1", Relationship = "0", Object = "2"
                }
            };
            A.CallTo(() => _sqlQueryConstructor.FindPredicatesAffectingObjectQuery(A<string>.Ignored)).Returns(sql);
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).Returns(nameValueData);

            var response = _databaseControl.FindPredicatesAffectingObject(null);

            response.ShouldAllBeEquivalentTo(data);
        }
    }
}
