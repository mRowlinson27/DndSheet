using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API;
using DataManipulation.API.DTOs;

namespace DataManipulation.API
{
    public interface IDataMapper
    {
        List<List<IControl>> SkillDtoToIcontrol(List<SkillsDto> skillsDto);
    }
}
