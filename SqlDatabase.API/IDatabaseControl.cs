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
        void InsertIntoEntities(List<TableEntity> tableEntities);
        void InsertIntoPredicates(List<Triple> triples);
        List<TableEntity> FindAllEntities();
        List<TableEntity> FindEntitiesByEid(List<int> eids);
        TableEntity FindEntityByEid(int eid);
        List<TableEntity> FindEntitiesByDatatype(string dataType);
        List<Triple> FindPredicatesAffectedBySubject(int subjectEid);
        List<Triple> FindPredicatesAffectingObject(int objectEid);
    }
}
