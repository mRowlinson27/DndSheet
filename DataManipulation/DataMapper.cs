using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API;
using CustomForms.API.Factories;
using DataManipulation.API;
using DataManipulation.API.DTOs;

namespace DataManipulation
{
    public class DataMapper : IDataMapper
    {
        private IEditableTextBoxBuilder _editableTextBoxBuilder;
        public DataMapper(IEditableTextBoxBuilder editableTextBoxBuilder)
        {
            _editableTextBoxBuilder = editableTextBoxBuilder;
        }

        public List<List<ITrueControl>> SkillDtoToIcontrol(List<SkillsDto> skillsDto)
        {
            var output = new List<List<ITrueControl>>();
            foreach (var skill in skillsDto)
            {
                var row = new List<ITrueControl>();

                row.Add(_editableTextBoxBuilder.Build(skill.SkillName));
                if (skill.Trained)
                {
                    row.Add(_editableTextBoxBuilder.Build("x"));
                }
                else
                {
                    row.Add(_editableTextBoxBuilder.Build("o"));
                }

                row.Add(_editableTextBoxBuilder.Build(skill.SkillRanks.ToString()));
                switch (skill.Modifier)
                {
                    case AbilityModifier.Str:
                        row.Add(_editableTextBoxBuilder.Build("STR"));
                        break;
                    case AbilityModifier.Dex:
                        row.Add(_editableTextBoxBuilder.Build("DEX"));
                        break;
                    case AbilityModifier.Con:
                        row.Add(_editableTextBoxBuilder.Build("CON"));
                        break;
                    case AbilityModifier.Wis:
                        row.Add(_editableTextBoxBuilder.Build("WIS"));
                        break;
                    case AbilityModifier.Int:
                        row.Add(_editableTextBoxBuilder.Build("INT"));
                        break;
                    case AbilityModifier.Cha:
                        row.Add(_editableTextBoxBuilder.Build("CHA"));
                        break;
                }
                if (skill.HasArmourCheckPenalty)
                {
                    row.Add(_editableTextBoxBuilder.Build(skill.ArmourCheckPenalty.ToString()));
                }
                output.Add(row);
            }
            return output;
        }
    }
}
