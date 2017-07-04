using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;
using SqlDatabase;
using SqlDatabase.Interfaces;

namespace UnitTests.SqLDatabase
{
    [TestFixture]
    public class SqLiteDatabaseBuilderTests
    {
        private IFileExplorer _fileExplorer;
        private IDatabaseTableConstants _databaseTableConstants;
        private ISqLiteConnectionWrapperFactory _connectionWrapperFactory;
        private ISqLiteConnectionWrapper _sqLiteConnectionWrapper;
        private SqLiteDatabaseBuilder _databaseBuilder;

        [SetUp]
        public void Setup()
        {
            _databaseTableConstants = A.Fake<IDatabaseTableConstants>();
            _fileExplorer = A.Fake<IFileExplorer>();
            _connectionWrapperFactory = A.Fake<ISqLiteConnectionWrapperFactory>();
            _sqLiteConnectionWrapper = A.Fake<ISqLiteConnectionWrapper>();
            _databaseBuilder = new SqLiteDatabaseBuilder(_databaseTableConstants,_fileExplorer, _connectionWrapperFactory);
        }

        [Test]
        public void Build_DatabaseExists_ConnectsOnly()
        {
            const string connection = "connection";
            A.CallTo(() => _connectionWrapperFactory.Create()).Returns(_sqLiteConnectionWrapper);
            A.CallTo(() => _fileExplorer.CheckFileExists(connection)).Returns(true);

            _databaseBuilder.Build(connection);

            A.CallTo(() => _sqLiteConnectionWrapper.Connect(connection)).MustHaveHappened();
            A.CallTo(() => _sqLiteConnectionWrapper.CreateFile(connection)).MustNotHaveHappened();
        }

        [Test]
        public void Build_DatabaseDoesNotExists_BuildsAndConnects()
        {
            const string connection = "connection";
            const string createEntiryTable = "createEntityTable";
            const string createPredicateTable = "createPredicateTable";
            A.CallTo(() => _connectionWrapperFactory.Create()).Returns(_sqLiteConnectionWrapper);
            A.CallTo(() => _fileExplorer.CheckFileExists(connection)).Returns(false);
            A.CallTo(() => _databaseTableConstants.CreateEntitiesTable).Returns(createEntiryTable);
            A.CallTo(() => _databaseTableConstants.CreatePredicatesTable).Returns(createPredicateTable);

            _databaseBuilder.Build(connection);

            A.CallTo(() => _sqLiteConnectionWrapper.CreateFile(connection)).MustHaveHappened();
            A.CallTo(() => _sqLiteConnectionWrapper.Connect(connection)).MustHaveHappened().
                Then(A.CallTo(() => _sqLiteConnectionWrapper.ExecuteNonQuery(createEntiryTable)).MustHaveHappened()).
                Then(A.CallTo(() => _sqLiteConnectionWrapper.ExecuteNonQuery(createPredicateTable)).MustHaveHappened());
        }
    }
}
