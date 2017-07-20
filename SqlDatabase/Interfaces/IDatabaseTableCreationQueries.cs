using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDatabase.Interfaces
{
    public interface IDatabaseTableCreationQueries
    {
        string CreateEntitiesTable { get; }
        string CreatePredicatesTable { get; }
        string PopulateDefaultEntities { get; }
        string PopulateDefaultPredicates { get; }
        string CreatePredicatesTrigger { get; }
    }
}
