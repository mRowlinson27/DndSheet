using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDatabase.API;
using SqlDatabase.Interfaces;

namespace SqlDatabase.Implementation
{
    public class SqLiteDatabaseFactory : ISqLiteDatabaseFactory
    {
        public ISqLiteDatabase Create(string connection, ISqLiteConnectionWrapperFactory sqLiteConnectionWrapperFactory)
        {
            return new SqLiteDatabase(connection, sqLiteConnectionWrapperFactory);
        }
    }
}
