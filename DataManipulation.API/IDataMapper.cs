using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.DTOs;

namespace DataManipulation.API
{
    public interface IDataMapper
    {
        List<List<string>> SkillDtoToStringsList(List<SkillsDto> skillsDto);
    }
}
