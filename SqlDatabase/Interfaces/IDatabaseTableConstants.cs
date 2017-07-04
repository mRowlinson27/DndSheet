using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDatabase.Interfaces
{
    public interface IDatabaseTableConstants
    {
        string CreateEntitiesTable { get; }
        string CreatePredicatesTable { get; }
    }
}
