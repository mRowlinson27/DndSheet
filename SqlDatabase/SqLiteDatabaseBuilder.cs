using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDatabase.API;
using SqlDatabase.Implementation;
using SqlDatabase.Interfaces;

namespace SqlDatabase
{
    public class SqLiteDatabaseBuilder
    {
        private readonly IDatabaseTableConstants _databaseTableConstants;
        private readonly IFileExplorer _fileExplorer;
        private readonly ISqLiteConnectionWrapperFactory _sqLiteConnectionWrapperFactory;

        public SqLiteDatabaseBuilder(IDatabaseTableConstants databaseTableConstants,IFileExplorer fileExplorer, ISqLiteConnectionWrapperFactory sqLiteConnectionWrapperFactory)
        {
            _databaseTableConstants = databaseTableConstants;
            _fileExplorer = fileExplorer;
            _sqLiteConnectionWrapperFactory = sqLiteConnectionWrapperFactory;
        }

        public ISqLiteDatabase Build(string connection)
        {
            var sqliteDatabase = new SqLiteDatabase(_sqLiteConnectionWrapperFactory.Create());

            if (!_fileExplorer.CheckFileExists(connection))
            {
                sqliteDatabase.CreateNewDatabase(connection);
                sqliteDatabase.Connect(connection);
                sqliteDatabase.ExecuteNonQuery(_databaseTableConstants.CreateEntitiesTable);
                sqliteDatabase.ExecuteNonQuery(_databaseTableConstants.CreatePredicatesTable);
            }
            else
            {
                sqliteDatabase.Connect(connection);
            }
            return sqliteDatabase;
        }
    }
}
