using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    Eid = "1", DataType = "String", Value = "Test"
                }
            };

            var sql = _sqlQueryConstructor.InsertIntoEntitiesQuery(data);
        }

        [Test]
        public void InsertIntoEntitiesQuery_MultipleEntities_CorrectSql()
        {
            var data = new List<TableEntity>
            {
                new TableEntity
                {
                    Eid = "1", DataType = "String", Value = "Test"
                },
                new TableEntity
                {
                    Eid = "2", DataType = "String", Value = "Test2"
                }
            };

            var sql = _sqlQueryConstructor.InsertIntoEntitiesQuery(data);
        }

        [Test]
        public void InsertIntoPredicatesQuery_SingleEntity_CorrectSql()
        {
            var data = new List<Triple>
            {
                new Triple
                {
                    Subject = "1", Relationship = "0", Object = "2"
                }
            };

            var sql = _sqlQueryConstructor.InsertIntoPredicatesQuery(data);
        }

        [Test]
        public void InsertIntoPredicatesQuery_MultipleEntities_CorrectSql()
        {
            var data = new List<Triple>
            {
                new Triple
                {
                    Subject = "1", Relationship = "0", Object = "2"
                },
                new Triple
                {
                    Subject = "2", Relationship = "0", Object = "1"
                }
            };

            var sql = _sqlQueryConstructor.InsertIntoPredicatesQuery(data);
        }
    }
}
