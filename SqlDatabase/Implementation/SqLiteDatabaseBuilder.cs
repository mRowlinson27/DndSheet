using SqlDatabase.API;
using SqlDatabase.Interfaces;

namespace SqlDatabase.Implementation
{
    public class SqLiteDatabaseBuilder
    {
        private readonly IDatabaseTableConstants _databaseTableConstants;
        private readonly IFileExplorer _fileExplorer;
        private readonly ISqLiteDatabaseFactory _sqLiteDatabaseFactory;
        private readonly ISqLiteConnectionWrapperFactory _sqLiteConnectionWrapperFactory;

        public SqLiteDatabaseBuilder(IDatabaseTableConstants databaseTableConstants, IFileExplorer fileExplorer, ISqLiteDatabaseFactory sqLiteDatabaseFactory, ISqLiteConnectionWrapperFactory sqLiteConnectionWrapperFactory)
        {
            _databaseTableConstants = databaseTableConstants;
            _fileExplorer = fileExplorer;
            _sqLiteDatabaseFactory = sqLiteDatabaseFactory;
            _sqLiteConnectionWrapperFactory = sqLiteConnectionWrapperFactory;
        }

        public ISqLiteDatabase Build(string connection)
        {
            ISqLiteDatabase sqliteDatabase;

            if (!_fileExplorer.CheckFileExists(connection))
            {
                _fileExplorer.CreateNewDatabase(connection);
                sqliteDatabase = _sqLiteDatabaseFactory.Create(connection, _sqLiteConnectionWrapperFactory);
                sqliteDatabase.ExecuteNonQuery(_databaseTableConstants.CreateEntitiesTable);
                sqliteDatabase.ExecuteNonQuery(_databaseTableConstants.CreatePredicatesTable);
            }
            else
            {
                sqliteDatabase = _sqLiteDatabaseFactory.Create(connection, _sqLiteConnectionWrapperFactory);
            }
            return sqliteDatabase;
        }
    }
}
