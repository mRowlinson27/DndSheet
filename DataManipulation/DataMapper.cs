using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API;
using DataManipulation.API.DTOs;

namespace DataManipulation
{
    public class DataMapper : IDataMapper
    {
        public List<List<string>> SkillDtoToStringsList(List<SkillsDto> skillsDto)
        {
            var output = new List<List<string>>();
            foreach (var skill in skillsDto)
            {
                var row = new List<string>();
                row.Add(skill.SkillName);
                if (skill.Trained)
                {
                    row.Add("x");
                }
                else
                {
                    row.Add("o");
                }

                row.Add(skill.SkillRanks.ToString());
                switch (skill.Modifier)
                {
                    case AbilityModifier.Str:
                        row.Add("STR");
                        break;
                    case AbilityModifier.Dex:
                        row.Add("DEX");
                        break;
                    case AbilityModifier.Con:
                        row.Add("CON");
                        break;
                    case AbilityModifier.Wis:
                        row.Add("WIS");
                        break;
                    case AbilityModifier.Int:
                        row.Add("INT");
                        break;
                    case AbilityModifier.Cha:
                        row.Add("CHA");
                        break;
                }
                if (skill.HasArmourCheckPenalty)
                {
                    row.Add(skill.ArmourCheckPenalty.ToString());
                }
                output.Add(row);
            }
            return output;
        }
    }
}
