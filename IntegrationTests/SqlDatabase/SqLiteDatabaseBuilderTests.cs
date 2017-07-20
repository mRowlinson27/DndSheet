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
        private IFileExplorer _fileExplorer;

        [SetUp]
        public void Setup()
        {
            _fileExplorer = new FileExplorer();
            _sqLiteDatabaseBuilder = new SqLiteDatabaseBuilder(new DatabaseTableCreationQueries(), _fileExplorer,
                new SqLiteDatabaseFactory(), new SqLiteConnectionWrapperFactory());
        }

        [Test]
        public void Build_CreateDefaultDatabase()
        {
           const string path = @"C:\Temp\TestDatabase.db";
            var dbControl = new DatabaseControl(_sqLiteDatabaseBuilder, new SqlQueryConstructor());
            _fileExplorer.DeleteFile(path);
            dbControl.Connect(path);

            var vals = dbControl.FindEidsWithGivenObjectType("Point");

            foreach (var val in vals)
            {
                var data = dbControl.FindTriplesAffectedBySubjectEid(val);
                Console.WriteLine($"{val}");
                foreach (var d in data)
                {
                    Console.WriteLine($"{d.Subject} - {d.Relationship} - {d.Object}");
                }
            }

            var vals2 = dbControl.FindTriplesAffectedBySubjectEid(8);

            foreach (var val in vals2)
            {
                Console.WriteLine($"{val.Object} - {val.Relationship} - {val.Subject}");
            }
        }
    }
}
