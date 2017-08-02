using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDatabase.API
{
    public interface IDatabaseConnector
    {
        IDatabase Connect(string connection);
    }
}
