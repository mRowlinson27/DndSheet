using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDatabase.Interfaces
{
    public interface ISqLiteDataReaderWrapper
    {
        bool Read();
        NameValueCollection GetValues();
    }
}
