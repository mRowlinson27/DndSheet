using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulation.API.DTOs
{
    public class EquationRequest
    {
        public int SubscriberEid { get; set; }
        public string DataType { get; set; }
        public string Value { get; set; }
    }
}
