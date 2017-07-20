using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SqlDatabase.API.DTO;
using SqlDatabase.Implementation;

namespace UnitTests.SqLDatabase
{
    [TestFixture]
    public class SqlQueryConstructorTests
    {
        private SqlQueryConstructor _sqlQueryConstructor;

        [SetUp]
        public void Setup()
        {
            _sqlQueryConstructor = new SqlQueryConstructor();
        }

        [Test]
        public void InsertIntoEntitiesQuery_SingleEntity_CorrectSql()
        {
            var data = new List<TableEntity>
            {
                new TableEntity
                {
                    Eid = 1, DataType = "String", Value = "Test"
                }
            };

            var sql = _sqlQueryConstructor.InsertIntoEntitiesQuery(data);

            sql.Should().Be(@"INSERT INTO Entities (Eid, DataType, Value) VALUES
(1, 'String', 'Test');");
        }

        [Test]
        public void InsertIntoEntitiesQuery_MultipleEntities_CorrectSql()
        {
            var data = new List<TableEntity>
            {
                new TableEntity
                {
                    Eid = 1, DataType = "String", Value = "Test"
                },
                new TableEntity
                {
                    Eid = 2, DataType = "String1", Value = "Test2"
                }
            };

            var sql = _sqlQueryConstructor.InsertIntoEntitiesQuery(data);

            sql.Should().Be(@"INSERT INTO Entities (Eid, DataType, Value) VALUES
(1, 'String', 'Test'),
(2, 'String1', 'Test2');");
        }

        [Test]
        public void UpdateEntitiesQuery_SingleEntity_CorrectSql()
        {
            var data = new List<TableEntity>
            {
                new TableEntity
                {
                    Eid = 1, DataType = "String", Value = "Test"
                }
            };

            var sql = _sqlQueryConstructor.UpdateEntitiesQuery(data);

            sql.Should().Be(@"UPDATE Entities
SET DataType =
CASE
WHEN Eid = 1 THEN 'String'
END,
Value =
CASE
WHEN Eid = 1 THEN 'Test'
END
WHERE
Eid IN (1);");
        }

        [Test]
        public void UpdateEntitiesQuery_MultipleEntities_CorrectSql()
        {
            var data = new List<TableEntity>
            {
                new TableEntity
                {
                    Eid = 1, DataType = "String", Value = "Test"
                },
                new TableEntity
                {
                    Eid = 2, DataType = "String1", Value = "Test2"
                }
            };

            var sql = _sqlQueryConstructor.UpdateEntitiesQuery(data);

            sql.Should().Be(@"UPDATE Entities
SET DataType =
CASE
WHEN Eid = 1 THEN 'String'
WHEN Eid = 2 THEN 'String1'
END,
Value =
CASE
WHEN Eid = 1 THEN 'Test'
WHEN Eid = 2 THEN 'Test2'
END
WHERE
Eid IN (1, 2);");
        }


        [Test]
        public void InsertIntoPredicatesQuery_SinglePredicate_CorrectSql()
        {
            var data = new List<Triple>
            {
                new Triple
                {
                    Subject = 1, Relationship = 0, Object = 2
                }
            };

            var sql = _sqlQueryConstructor.InsertIntoPredicatesQuery(data);

            sql.Should().Be(@"INSERT INTO Predicates (Subject, Relationship, Object) VALUES
(1, 0, 2);");
        }

        [Test]
        public void InsertIntoPredicatesQuery_MultiplePredicates_CorrectSql()
        {
            var data = new List<Triple>
            {
                new Triple
                {
                    Subject = 1, Relationship = 0, Object = 2
                },
                new Triple
                {
                    Subject = 2, Relationship = 0, Object = 1
                }
            };

            var sql = _sqlQueryConstructor.InsertIntoPredicatesQuery(data);

            sql.Should().Be(@"INSERT INTO Predicates (Subject, Relationship, Object) VALUES
(1, 0, 2),
(2, 0, 1);");
        }

        [Test]
        public void UpdatePredicatesQuery_SinglePredicate_CorrectSql()
        {
            var data = new List<Triple>
            {
                new Triple
                {
                    Subject = 1, Relationship = 0, Object = 2
                }
            };

            var sql = _sqlQueryConstructor.UpdatePredicatesQuery(data);

            sql.Should().Be(@"UPDATE Predicates
SET Relationship =
CASE
WHEN Subject = 1 AND Object = 2 THEN 0
END
WHERE
Subject = 1 AND Object = 2;");
        }

        [Test]
        public void UpdatePredicatesQuery_MultiplePredicates_CorrectSql()
        {
            var data = new List<Triple>
            {
                new Triple
                {
                    Subject = 1, Relationship = 0, Object = 2
                },
                new Triple
                {
                    Subject = 2, Relationship = 10, Object = 1
                }
            };

            var sql = _sqlQueryConstructor.UpdatePredicatesQuery(data);

            sql.Should().Be(@"UPDATE Predicates
SET Relationship =
CASE
WHEN Subject = 1 AND Object = 2 THEN 0
WHEN Subject = 2 AND Object = 1 THEN 10
END
WHERE
Subject = 1 AND Object = 2 OR Subject = 2 AND Object = 1;");
        }

        [Test]
        public void FindAllEntitiesQuery_CorrectSql()
        {

            var sql = _sqlQueryConstructor.FindAllEntitiesQuery();

            sql.Should().Be(@"SELECT * FROM Entities;");
        }

        [Test]
        public void FindEntitiesByEidQuery_SingleEntity_CorrectSql()
        {
            var eids = new List<int>
            {
                1
            };

            var sql = _sqlQueryConstructor.FindEntitiesByEidQuery(eids);

            sql.Should().Be(@"SELECT * FROM Entities
WHERE Eid = 1;");
        }

        [Test]
        public void FindEntitiesByEidQuery_MultipleEntities_CorrectSql()
        {
            var eids = new List<int>
            {
                1,
                2
            };

            var sql = _sqlQueryConstructor.FindEntitiesByEidQuery(eids);

            sql.Should().Be(@"SELECT * FROM Entities
WHERE Eid = 1 OR Eid = 2;");
        }

        [Test]
        public void FindEntitiesByDataTypeQuery()
        {
            var dataType = "String";

            var sql = _sqlQueryConstructor.FindEntitiesByDataTypeQuery(dataType);

            sql.Should().Be(@"SELECT * FROM Entities
WHERE DataType = 'String';");
        }

        [Test]
        public void FindPredicatesAffectedBySubjectQuery()
        {
            var subject = 1;

            var sql = _sqlQueryConstructor.FindTriplesAffectedBySubjectQuery(subject);

            sql.Should().Be(@"SELECT * FROM Predicates
WHERE Subject = 1;");
        }

        [Test]
        public void FindPredicatesAffectingObjectQuery()
        {
            var subject = 1;

            var sql = _sqlQueryConstructor.FindTriplesAffectingObjectQuery(subject);

            sql.Should().Be(@"SELECT * FROM Predicates
WHERE Object = 1;");
        }
    }
}
