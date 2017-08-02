using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulation.API.Point
{
    public interface IPointValue
    {
        int Eid { get; }
        string DataType { get; }
        string Value { get; }
    }
}
