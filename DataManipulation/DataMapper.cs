using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API;
using CustomForms.API.Factories;
using CustomFormStructures.API.Builders;
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

                row.Add(_editableTextBoxBuilder.Build(skill.SkillName, null, null));
                if (skill.Trained)
                {
                    row.Add(_editableTextBoxBuilder.Build("x", null, null));
                }
                else
                {
                    row.Add(_editableTextBoxBuilder.Build("o", null, null));
                }

                row.Add(_editableTextBoxBuilder.Build(skill.SkillRanks.ToString(), null, null));
                switch (skill.Modifier)
                {
                    case AbilityModifier.Str:
                        row.Add(_editableTextBoxBuilder.Build("STR", null, null));
                        break;
                    case AbilityModifier.Dex:
                        row.Add(_editableTextBoxBuilder.Build("DEX", null, null));
                        break;
                    case AbilityModifier.Con:
                        row.Add(_editableTextBoxBuilder.Build("CON", null, null));
                        break;
                    case AbilityModifier.Wis:
                        row.Add(_editableTextBoxBuilder.Build("WIS", null, null));
                        break;
                    case AbilityModifier.Int:
                        row.Add(_editableTextBoxBuilder.Build("INT", null, null));
                        break;
                    case AbilityModifier.Cha:
                        row.Add(_editableTextBoxBuilder.Build("CHA", null, null));
                        break;
                }
                if (skill.HasArmourCheckPenalty)
                {
                    row.Add(_editableTextBoxBuilder.Build(skill.ArmourCheckPenalty.ToString(), null, null));
                }
                output.Add(row);
            }
            return output;
        }
    }
}
