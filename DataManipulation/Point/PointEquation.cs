using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.Point;

namespace DataManipulation.Point
{
    public class PointEquation : IPointEquation
    {
        public event EventHandler Updated;
        public int Eid { get; set; }
        public string Value { get; }
        public string Evaluate(string value, string dataType)
        {
            throw new NotImplementedException();
        }
    }
}
