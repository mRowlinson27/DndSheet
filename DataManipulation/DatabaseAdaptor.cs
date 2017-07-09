using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API;
using DataManipulation.API.DataPoint;
using SqlDatabase.API.DTO;

namespace DataManipulation
{
    public class DatabaseAdaptor : IDatabaseAdaptor
    {
        public void Connect(string connection)
        {
            throw new NotImplementedException();
        }

        public void InsertIntoEntites(List<TableEntity> tableEntities)
        {
            throw new NotImplementedException();
        }

        public void InsertIntoPredicates(List<Triple> triples)
        {
            throw new NotImplementedException();
        }

        public List<IDataPoint> FindEntitiesByEid(List<string> eids)
        {
            throw new NotImplementedException();
        }

        public IDataPoint FindEntityByEid(string eid)
        {
            throw new NotImplementedException();
        }

        public List<IDataPoint> FindEntitiesByDatatype(string dataType)
        {
            throw new NotImplementedException();
        }

        public List<Triple> FindPredicatesAffectedBySubject(string subjectEid)
        {
            throw new NotImplementedException();
        }

        public List<Triple> FindPredicatesAffectingObject(string objectEid)
        {
            throw new NotImplementedException();
        }
    }
}
