using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.DTOs;

namespace DataManipulation.API.Point
{
    public interface IPointEquation
    {
        event EventHandler Updated;
        int Eid { get; set; }
        string Value { get; }
        string Evaluate(string value, string dataType);
    }
}
