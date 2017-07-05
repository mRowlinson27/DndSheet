using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDatabase.API
{
    public interface ISqLiteDatabase
    {
        void ExecuteNonQuery(string sql);
        List<NameValueCollection> ExecuteReader(string sql);
    }
}
