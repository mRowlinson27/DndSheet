using System.Collections.Generic;
using CustomForms.API;
using DataManipulation.API.DTOs;

namespace CustomFormManipulation.API
{
    public interface IDataMapper
    {
        List<List<ITrueControl>> SkillDtoToIcontrol(List<SkillsDto> skillsDto);
    }
}
