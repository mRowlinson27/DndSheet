using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDatabase.API.DTO
{
    public class SqlData
    {
        public int Eid { get; set; }
        public string Relationship { get; set; }
        public string ExtendedRelationship { get; set; }
        public string Value { get; set; }
    }
}
