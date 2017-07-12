using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulation.API.Point
{
    public interface IPointFactory
    {
        IPoint Create(int eid, IPointComponentsBuilder pointComponentsBuilder);
    }
}
