using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulation.DTO
{
    public class PointEquation
    {
        public PointEquation(int eid, string value)
        {
            Eid = eid;
            Value = value;
        }

        public int Eid { get; set; }
        public string Value { get; set; }
    }
}
