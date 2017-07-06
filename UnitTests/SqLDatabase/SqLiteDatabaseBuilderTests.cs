using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;
using SqlDatabase;
using SqlDatabase.API;
using SqlDatabase.Implementation;
using SqlDatabase.Interfaces;

namespace UnitTests.SqLDatabase
{
    [TestFixture]
    public class SqLiteDatabaseBuilderTests
    {
        private IFileExplorer _fileExplorer;
        private IDatabaseTableCreationQueries _databaseTableCreationQueries;
        private ISqLiteConnectionWrapperFactory _connectionWrapperFactory;
        private ISqLiteDatabaseFactory _sqLiteDatabaseFactory;
        private ISqLiteDatabase _sqLiteDatabase;
        private SqLiteDatabaseBuilder _databaseBuilder;

        [SetUp]
        public void Setup()
        {
            _databaseTableCreationQueries = A.Fake<IDatabaseTableCreationQueries>();
            _fileExplorer = A.Fake<IFileExplorer>();
            _connectionWrapperFactory = A.Fake<ISqLiteConnectionWrapperFactory>();
            _sqLiteDatabaseFactory = A.Fake<ISqLiteDatabaseFactory>();
            _sqLiteDatabase = A.Fake<ISqLiteDatabase>();
            _databaseBuilder = new SqLiteDatabaseBuilder(_databaseTableCreationQueries, _fileExplorer, _sqLiteDatabaseFactory, _connectionWrapperFactory);
        }

        [Test]
        public void Build_DatabaseExists_ConnectsOnly()
        {
            const string connection = "connection";
            A.CallTo(() => _fileExplorer.CheckFileExists(connection)).Returns(true);
            A.CallTo(() => _sqLiteDatabaseFactory.Create(connection, _connectionWrapperFactory)).Returns(_sqLiteDatabase);

            _databaseBuilder.Build(connection);

            A.CallTo(() => _sqLiteDatabaseFactory.Create(connection, _connectionWrapperFactory)).MustHaveHappened();
            A.CallTo(() => _fileExplorer.CreateNewDatabase(connection)).MustNotHaveHappened();
        }

        [Test]
        public void Build_DatabaseDoesNotExists_BuildsAndConnects()
        {
            const string connection = "connection";
            const string createEntiryTable = "createEntityTable";
            const string createPredicateTable = "createPredicateTable";
            A.CallTo(() => _fileExplorer.CheckFileExists(connection)).Returns(false);
            A.CallTo(() => _sqLiteDatabaseFactory.Create(connection, _connectionWrapperFactory)).Returns(_sqLiteDatabase);
            A.CallTo(() => _databaseTableCreationQueries.CreateEntitiesTable).Returns(createEntiryTable);
            A.CallTo(() => _databaseTableCreationQueries.CreatePredicatesTable).Returns(createPredicateTable);

            _databaseBuilder.Build(connection);

            A.CallTo(() => _fileExplorer.CreateNewDatabase(connection)).MustHaveHappened();
            A.CallTo(() => _sqLiteDatabaseFactory.Create(connection, _connectionWrapperFactory)).MustHaveHappened().
                Then(A.CallTo(() => _sqLiteDatabase.ExecuteNonQuery(createEntiryTable)).MustHaveHappened()).
                Then(A.CallTo(() => _sqLiteDatabase.ExecuteNonQuery(createPredicateTable)).MustHaveHappened());
        }
    }
}
