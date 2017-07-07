using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDatabase.API.DTO;

namespace DataManipulation.API.DTOs
{
    public class SqlAbilityScore
    {
        public TableEntity Location { get; set; }
        public TableEntity Name { get; set; }
        public TableEntity Abr { get; set; }
        public TableEntity Value { get; set; }
    }
}
