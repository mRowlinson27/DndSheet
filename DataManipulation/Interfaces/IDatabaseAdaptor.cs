using System.Collections.Generic;

namespace DataManipulation.Interfaces
{
    public interface IDatabaseAdaptor
    {
        void Connect(string connection);
        List<IPoint> FindEntitiesByEid(List<string> eids);
        IPoint FindEntityByEid(string eid);
        List<IPoint> FindEntitiesByDatatype(string dataType);
    }
}
