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
        private IEditableTextBoxFactory _editableTextBoxFactory;
        public DataMapper(IEditableTextBoxFactory editableTextBoxFactory)
        {
            _editableTextBoxFactory = editableTextBoxFactory;
        }

        public List<List<IControl>> SkillDtoToIcontrol(List<SkillsDto> skillsDto)
        {
            var output = new List<List<IControl>>();
            foreach (var skill in skillsDto)
            {
                var row = new List<IControl>();

                row.Add(_editableTextBoxFactory.Create(skill.SkillName));
                if (skill.Trained)
                {
                    row.Add(_editableTextBoxFactory.Create("x"));
                }
                else
                {
                    row.Add(_editableTextBoxFactory.Create("o"));
                }

                row.Add(_editableTextBoxFactory.Create(skill.SkillRanks.ToString()));
                switch (skill.Modifier)
                {
                    case AbilityModifier.Str:
                        row.Add(_editableTextBoxFactory.Create("STR"));
                        break;
                    case AbilityModifier.Dex:
                        row.Add(_editableTextBoxFactory.Create("DEX"));
                        break;
                    case AbilityModifier.Con:
                        row.Add(_editableTextBoxFactory.Create("CON"));
                        break;
                    case AbilityModifier.Wis:
                        row.Add(_editableTextBoxFactory.Create("WIS"));
                        break;
                    case AbilityModifier.Int:
                        row.Add(_editableTextBoxFactory.Create("INT"));
                        break;
                    case AbilityModifier.Cha:
                        row.Add(_editableTextBoxFactory.Create("CHA"));
                        break;
                }
                if (skill.HasArmourCheckPenalty)
                {
                    row.Add(_editableTextBoxFactory.Create(skill.ArmourCheckPenalty.ToString()));
                }
                output.Add(row);
            }
            return output;
        }
    }
}
