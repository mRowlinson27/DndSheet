using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API.DTOs;

namespace CustomForms.DTOs
{
    class SkillRankDto : IDataValue
    {
        public int DataValueId { get; set; }
        public int Ranks { get; set; }
    }
}
