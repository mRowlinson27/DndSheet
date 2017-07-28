using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDatabase.API.DTO;

namespace SqlDatabase.API
{
    public interface IDatabase
    {
        event EventHandler EntityDeleted;
        event EventHandler Connected;
        void Connect(string connection);
        void InsertIntoEntities(List<TableEntity> tableEntities);
        void InsertIntoPredicates(List<Triple> triples);
        List<TableEntity> FindAllEntities();
        List<TableEntity> FindEntitiesByEid(List<int> eids);
        TableEntity FindEntityByEid(int eid);
        List<TableEntity> FindEntitiesByDatatype(string dataType);
        List<Triple> FindTriplesAffectedBySubjectEid(int subjectEid);
        List<Triple> FindTriplesAffectingObjectEid(int objectEid);
        List<int> FindEidsWithGivenObjectType(string objectType);
        List<int> FindAllEids();
        List<SqlData> FindObjectDetailsFromEid(int eid);
    }
}
