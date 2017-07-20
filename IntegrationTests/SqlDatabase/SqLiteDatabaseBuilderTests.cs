using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SqlDatabase;
using SqlDatabase.Implementation;

namespace IntegrationTests.SqlDatabase
{
    [TestFixture]
    public class SqLiteDatabaseBuilderTests
    {
        private SqLiteDatabaseBuilder _sqLiteDatabaseBuilder;

        [SetUp]
        public void Setup()
        {
            _sqLiteDatabaseBuilder = new SqLiteDatabaseBuilder(new DatabaseTableCreationQueries(), new FileExplorer(),
                new SqLiteDatabaseFactory(), new SqLiteConnectionWrapperFactory());
        }

        [Test]
        public void Build_CreateDefaultDatabase()
        {
           
            var dbControl = new DatabaseControl(_sqLiteDatabaseBuilder, new SqlQueryConstructor());
            dbControl.Connect(@"C:\Temp\TestDatabase.db");

            var vals = dbControl.FindAllEntities();

            foreach (var val in vals)
            {
                Console.WriteLine($"{val.Eid} - {val.DataType} - {val.Value}");
            }

            var vals2 = dbControl.FindPredicatesAffectedBySubject(8);

            foreach (var val in vals2)
            {
                Console.WriteLine($"{val.Object} - {val.Relationship} - {val.Subject}");
            }
        }
    }
}
