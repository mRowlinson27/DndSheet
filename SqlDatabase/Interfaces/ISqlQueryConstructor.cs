using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SqlDatabase.API.DTO;

namespace SqlDatabase.Interfaces
{
    public interface ISqlQueryConstructor
    {
        string InsertIntoEntitiesQuery(List<TableEntity> tableEntities);
        string UpdateEntitiesQuery(List<TableEntity> tableEntities);
        string InsertIntoPredicatesQuery(List<Triple> triples);
        string UpdatePredicatesQuery(List<Triple> triples);
        string FindEntitiesByEidQuery(List<string> eids);
        string FindEntitiesByDataTypeQuery(string dataType);
        string FindPredicatesAffectedBySubjectQuery(string subjectEid);
        string FindPredicatesAffectingObjectQuery(string objectEid);
    }
}
