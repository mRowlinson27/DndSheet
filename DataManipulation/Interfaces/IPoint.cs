using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulation.Interfaces
{
    public interface IPoint
    {
        int Eid { get; }
        string DataType { get; set; }
        string Value { get; set; }
        string Output { get; set; }
        event EventHandler Updated;
        void Update();
    }
}
