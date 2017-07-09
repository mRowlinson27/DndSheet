using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.DataPoint;
using SqlDatabase.API.DTO;

namespace DataManipulation.API
{
    public interface IDatabaseAdaptor
    {
        void Connect(string connection);
        void InsertIntoEntites(List<TableEntity> tableEntities);
        void InsertIntoPredicates(List<Triple> triples);
        List<IDataPoint> FindEntitiesByEid(List<string> eids);
        IDataPoint FindEntityByEid(string eid);
        List<IDataPoint> FindEntitiesByDatatype(string dataType);
        List<Triple> FindPredicatesAffectedBySubject(string subjectEid);
        List<Triple> FindPredicatesAffectingObject(string objectEid);
    }
}
