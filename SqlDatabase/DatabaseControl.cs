using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDatabase.API;
using SqlDatabase.Implementation;

namespace SqlDatabase
{
    public class DatabaseControl
    {
        private ISqLiteDatabase _sqLiteDatabase;

        public void Initialize(string connection)
        {
            _sqLiteDatabase = new SqLiteDatabaseBuilder(new DatabaseTableConstants(), new FileExplorer(),new SqLiteDatabaseFactory(), new SqLiteConnectionWrapperFactory()).Build(connection);
        }
    }
}
