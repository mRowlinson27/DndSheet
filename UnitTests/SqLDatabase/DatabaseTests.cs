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
    public class DatabaseTests
    {
        private Database _database;
        private ISqLiteDatabaseBuilder _databaseBuilder;
        private ISqlQueryConstructor _sqlQueryConstructor;
        private ISqLiteDatabase _sqLiteDatabase;

        [SetUp]
        public void Setup()
        {
            _databaseBuilder = A.Fake<ISqLiteDatabaseBuilder>();
            _sqlQueryConstructor = A.Fake<ISqlQueryConstructor>();
            _sqLiteDatabase = A.Fake<ISqLiteDatabase>();
            _database = new Database(_databaseBuilder, _sqlQueryConstructor);
        }

        [Test]
        public void Connect_BuildsConnection()
        {
            const string path = @"C:\Temp\MYDATABASE.db";
            _database.Connect(path);

            A.CallTo(() => _databaseBuilder.Build(path)).MustHaveHappened();
        }

        [Test]
        public void InsertIntoEntites_GetsSqlAndExecutesAsNonQuery()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);

            _database.Connect(path);
            var data = new List<TableEntity>
            {
                new TableEntity()
            };

            A.CallTo(() => _sqlQueryConstructor.InsertIntoEntitiesQuery(data)).Returns(sql);

            _database.InsertIntoEntities(data);

            A.CallTo(() => _sqlQueryConstructor.InsertIntoEntitiesQuery(data)).MustHaveHappened();
            A.CallTo(() => _sqLiteDatabase.ExecuteNonQuery(sql)).MustHaveHappened();
        }

        [Test]
        public void InsertIntoPredicates_GetsSqlAndExecutesAsNonQuery()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);

            _database.Connect(path);
            var data = new List<Triple>
            {
                new Triple()
            };

            A.CallTo(() => _sqlQueryConstructor.InsertIntoPredicatesQuery(data)).Returns(sql);

            _database.InsertIntoPredicates(data);

            A.CallTo(() => _sqlQueryConstructor.InsertIntoPredicatesQuery(data)).MustHaveHappened();
            A.CallTo(() => _sqLiteDatabase.ExecuteNonQuery(sql)).MustHaveHappened();
        }

        [Test]
        public void FindAllEntities_GetsSqlAndExecutesAsQuery()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);

            _database.Connect(path);
            var nameValueData = new List<NameValueCollection>
            {
                new NameValueCollection()
                {
                    {"Eid", "1"}, {"DataType", "String"}, {"Value", "Test"}
                }
            };

            A.CallTo(() => _sqlQueryConstructor.FindAllEntitiesQuery()).Returns(sql);
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).Returns(nameValueData);

            _database.FindAllEntities();

            A.CallTo(() => _sqlQueryConstructor.FindAllEntitiesQuery()).MustHaveHappened();
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).MustHaveHappened();
        }

        [Test]
        public void FindAllEntities_ReturnsProperTableEntities()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);

            _database.Connect(path);
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

            A.CallTo(() => _sqlQueryConstructor.FindAllEntitiesQuery()).Returns(sql);
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).Returns(nameValueData);

            var response = _database.FindAllEntities();

            response.ShouldAllBeEquivalentTo(data);
        }

        [Test]
        public void FindEntitiesByEid_GetsSqlAndExecutesAsQuery()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);

            _database.Connect(path);
            var nameValueData = new List<NameValueCollection>
            {
                new NameValueCollection()
                {
                    {"Eid", "1"}, {"DataType", "String"}, {"Value", "Test"}
                }
            };

            A.CallTo(() => _sqlQueryConstructor.FindEntitiesByEidQuery(A<List<int>>.Ignored)).Returns(sql);
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).Returns(nameValueData);

            _database.FindEntitiesByEid(null);

            A.CallTo(() => _sqlQueryConstructor.FindEntitiesByEidQuery(null)).MustHaveHappened();
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).MustHaveHappened();
        }

        [Test]
        public void FindEntitiesByEid_ReturnsProperTableEntities()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);

            _database.Connect(path);
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

            A.CallTo(() => _sqlQueryConstructor.FindEntitiesByEidQuery(A<List<int>>.Ignored)).Returns(sql);
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).Returns(nameValueData);

            var response = _database.FindEntitiesByEid(null);

            response.ShouldAllBeEquivalentTo(data);
        }

        [Test]
        public void FindEntitiesByDataType_GetsSqlAndExecutesAsQuery()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);
            _database.Connect(path);
            var nameValueData = new List<NameValueCollection>
            {
                new NameValueCollection()
                {
                    {"Eid", "1"}, {"DataType", "String"}, {"Value", "Test"}
                }
            };
            A.CallTo(() => _sqlQueryConstructor.FindEntitiesByDataTypeQuery(A<string>.Ignored)).Returns(sql);
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).Returns(nameValueData);

            _database.FindEntitiesByDatatype(null);

            A.CallTo(() => _sqlQueryConstructor.FindEntitiesByDataTypeQuery(null)).MustHaveHappened();
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).MustHaveHappened();
        }

        [Test]
        public void FindEntitiesByDataType_ReturnsProperTableEntities()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);
            _database.Connect(path);
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

            var response = _database.FindEntitiesByDatatype(null);

            response.ShouldAllBeEquivalentTo(data);
        }

        [Test]
        public void FindPredicatesAffectedBySubject_GetsSqlAndExecutesAsQuery()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);
            _database.Connect(path);
            var nameValueData = new List<NameValueCollection>
            {
                new NameValueCollection()
                {
                    {"Subject", "1"}, {"Relationship", "0"}, {"Object", "2"}
                }
            };
            A.CallTo(() => _sqlQueryConstructor.FindTriplesAffectedBySubjectQuery(A<int>.Ignored)).Returns(sql);
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).Returns(nameValueData);

            _database.FindTriplesAffectedBySubjectEid(1);

            A.CallTo(() => _sqlQueryConstructor.FindTriplesAffectedBySubjectQuery(1)).MustHaveHappened();
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).MustHaveHappened();
        }

        [Test]
        public void FindPredicatesAffectedBySubject_ReturnsProperTriples()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);
            _database.Connect(path);
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
                    Subject = 1, Relationship = 0, Object = 2
                }
            };
            A.CallTo(() => _sqlQueryConstructor.FindTriplesAffectedBySubjectQuery(A<int>.Ignored)).Returns(sql);
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).Returns(nameValueData);

            var response = _database.FindTriplesAffectedBySubjectEid(1);

            response.ShouldAllBeEquivalentTo(data);
        }

        [Test]
        public void FindPredicatesAffectingObject_GetsSqlAndExecutesAsQuery()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);
            _database.Connect(path);
            var nameValueData = new List<NameValueCollection>
            {
                new NameValueCollection()
                {
                    {"Subject", "1"}, {"Relationship", "0"}, {"Object", "2"}
                }
            };
            A.CallTo(() => _sqlQueryConstructor.FindTriplesAffectingObjectQuery(A<int>.Ignored)).Returns(sql);
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).Returns(nameValueData);

            _database.FindTriplesAffectingObjectEid(1);

            A.CallTo(() => _sqlQueryConstructor.FindTriplesAffectingObjectQuery(1)).MustHaveHappened();
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).MustHaveHappened();
        }

        [Test]
        public void FindPredicatesAffectingObject_ReturnsProperTriples()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);
            _database.Connect(path);
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
                    Subject = 1, Relationship = 0, Object = 2
                }
            };
            A.CallTo(() => _sqlQueryConstructor.FindTriplesAffectingObjectQuery(A<int>.Ignored)).Returns(sql);
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).Returns(nameValueData);

            var response = _database.FindTriplesAffectingObjectEid(1);

            response.ShouldAllBeEquivalentTo(data);
        }

        [Test]
        public void FindEidsWithGivenObjectType_GetsSqlAndExecutesAsQuery()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);
            _database.Connect(path);
            var nameValueData = new List<NameValueCollection>
            {
                new NameValueCollection()
                {
                    {"Subject", "1"}
                },
                new NameValueCollection()
                {
                    {"Subject", "2"}
                }
            };
            var data = new List<int>
            {
                1, 2
            };
            A.CallTo(() => _sqlQueryConstructor.FindEidsWithGivenObjectTypeQuery(A<string>.Ignored)).Returns(sql);
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).Returns(nameValueData);

            var response = _database.FindEidsWithGivenObjectType("");

            response.ShouldAllBeEquivalentTo(data);
        }

        [Test]
        public void FindDetailsFromEid_GetsSqlAndExecutesAsQuery()
        {
            const string sql = "sql";
            const string path = @"C:\Temp\MYDATABASE.db";
            var correctSqlData = new SqlData()
            {
                Eid = 1,
                Relationship = "HasValue",
                ExtendedRelationship = "ObjectType",
                Value = "Int"
            };
            A.CallTo(() => _databaseBuilder.Build(path)).Returns(_sqLiteDatabase);
            _database.Connect(path);
            var nameValueData = new List<NameValueCollection>
            {
                new NameValueCollection()
                {
                    { "Subject", "1"},
                    { "Relationship", "HasValue" },
                    { "ExtendedRelationship", "ObjectType" },
                    { "Value", "Int" }
                },
            };
            A.CallTo(() => _sqlQueryConstructor.FindObjectDetailsFromEid(A<int>.Ignored)).Returns(sql);
            A.CallTo(() => _sqLiteDatabase.ExecuteReader(sql)).Returns(nameValueData);

            var response = _database.FindObjectDetailsFromEid(1);

            response.ShouldBeEquivalentTo(new List<SqlData>() { correctSqlData });
        }
    }
}
