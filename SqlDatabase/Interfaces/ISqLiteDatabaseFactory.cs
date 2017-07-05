using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDatabase.API;

namespace SqlDatabase.Interfaces
{
    public interface ISqLiteDatabaseFactory
    {
        ISqLiteDatabase Create(string connection, ISqLiteConnectionWrapperFactory sqLiteConnectionWrapperFactory);
    }
}
