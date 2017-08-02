using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.Point;
using SqlDatabase.API.DTO;

namespace DataManipulation.API
{
    public interface IDatabaseAdaptor
    {
        void Connect(string connection);
        List<IPoint> FindEntitiesByEid(List<string> eids);
        IPoint FindEntityByEid(string eid);
        List<IPoint> FindEntitiesByDatatype(string dataType);
    }
}
