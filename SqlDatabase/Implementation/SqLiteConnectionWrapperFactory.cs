using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDatabase.Interfaces;

namespace SqlDatabase.Implementation
{
    public class SqLiteConnectionWrapperFactory : ISqLiteConnectionWrapperFactory
    {
        public ISqLiteConnectionWrapper Create(string connection)
        {
            return new SqLiteConnectionWrapper(connection);
        }
    }
}
