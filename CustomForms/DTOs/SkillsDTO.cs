using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API.DTOs;

namespace CustomForms.DTOs
{
    class SkillsDto : IDataValue
    {
        public int DataValueId { get; set; }
        public SkillNameDto SkillName { get; set; }
        public SkillRankDto SkillRank { get; set; }

        public SkillsDto()
        {
            
        }
    }
}
