using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDatabase.API.DTO;
using SqlDatabase.Interfaces;

namespace SqlDatabase.Implementation
{
    public class SqlQueryConstructor : ISqlQueryConstructor
    {
        public string InsertIntoEntitiesQuery(List<TableEntity> tableEntities)
        {
            throw new NotImplementedException();
        }

        public string InsertIntoPredicatesQuery(List<Triple> triples)
        {
            throw new NotImplementedException();
        }

        public string FindEntitiesByEidQuery(List<string> eids)
        {
            throw new NotImplementedException();
        }

        public string FindEntitiesByDataTypeQuery(string dataType)
        {
            throw new NotImplementedException();
        }

        public string FindPredicatesAffectedBySubjectQuery(string subjectEid)
        {
            throw new NotImplementedException();
        }

        public string FindPredicatesAffectingObjectQuery(string objectEid)
        {
            throw new NotImplementedException();
        }
    }
}
