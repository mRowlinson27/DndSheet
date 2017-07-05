using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDatabase.API.DTO;

namespace SqlDatabase.API
{
    public interface IDatabaseControl
    {
        void Connect(string connection);
        void InsertIntoEntites(List<TableEntity> tableEntities);
        void InsertIntoPredicates(List<Triple> triples);
        List<TableEntity> FindEntitiesByEid(List<string> eids);
        List<TableEntity> FindEntitiesByDatatype(string dataType);
        List<Triple> FindPredicatesAffectedBySubject(string subjectEid);
        List<Triple> FindPredicatesAffectingObject(string objectEid);
    }
}
