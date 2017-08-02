using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulation.API.Point
{
    public interface IPointEquation
    {
        int Eid { get; set; }
        string Value { get; }
        string Evaluate(IPointValue value);
    }
}
