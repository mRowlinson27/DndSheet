using SqlDatabase.API;
using SqlDatabase.Interfaces;

namespace SqlDatabase.Implementation
{
    public class SqLiteDatabaseBuilder : ISqLiteDatabaseBuilder
    {
        private readonly IDatabaseTableCreationQueries _databaseTableCreationQueries;
        private readonly IFileExplorer _fileExplorer;
        private readonly ISqLiteDatabaseFactory _sqLiteDatabaseFactory;
        private readonly ISqLiteConnectionWrapperFactory _sqLiteConnectionWrapperFactory;

        public SqLiteDatabaseBuilder(IDatabaseTableCreationQueries databaseTableCreationQueries, IFileExplorer fileExplorer, ISqLiteDatabaseFactory sqLiteDatabaseFactory, ISqLiteConnectionWrapperFactory sqLiteConnectionWrapperFactory)
        {
            _databaseTableCreationQueries = databaseTableCreationQueries;
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
                sqliteDatabase.ExecuteNonQuery(_databaseTableCreationQueries.CreateEntitiesTable);
                sqliteDatabase.ExecuteNonQuery(_databaseTableCreationQueries.CreatePredicatesTable);
                sqliteDatabase.ExecuteNonQuery(_databaseTableCreationQueries.CreatePredicatesTrigger);
                sqliteDatabase.ExecuteNonQuery(_databaseTableCreationQueries.PopulateDefaultEntities);
                sqliteDatabase.ExecuteNonQuery(_databaseTableCreationQueries.PopulateDefaultPredicates);
            }
            else
            {
                sqliteDatabase = _sqLiteDatabaseFactory.Create(connection, _sqLiteConnectionWrapperFactory);
            }
            return sqliteDatabase;
        }
    }
}
