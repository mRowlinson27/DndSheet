using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomFormManipulation.DTOs;
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
            var inEditStyle = new ControlPropertiesStyle() {BackColor = Color.BlueViolet };
            var notInEditStyle = new ControlPropertiesStyle() {BackColor = Color.Transparent};
            var output = new List<List<ITrueControl>>();
            foreach (var skill in skillsDto)
            {
                var row = new List<ITrueControl>();

                row.Add(_editableTextBoxBuilder.Build(skill.SkillName, inEditStyle, notInEditStyle));
                if (skill.Trained)
                {
                    row.Add(_editableTextBoxBuilder.Build("x", inEditStyle, notInEditStyle));
                }
                else
                {
                    row.Add(_editableTextBoxBuilder.Build("o", inEditStyle, notInEditStyle));
                }

                row.Add(_editableTextBoxBuilder.Build(skill.SkillRanks.ToString(), inEditStyle, notInEditStyle));
                switch (skill.Modifier)
                {
                    case AbilityModifier.Str:
                        row.Add(_editableTextBoxBuilder.Build("STR", inEditStyle, notInEditStyle));
                        break;
                    case AbilityModifier.Dex:
                        row.Add(_editableTextBoxBuilder.Build("DEX", inEditStyle, notInEditStyle));
                        break;
                    case AbilityModifier.Con:
                        row.Add(_editableTextBoxBuilder.Build("CON", inEditStyle, notInEditStyle));
                        break;
                    case AbilityModifier.Wis:
                        row.Add(_editableTextBoxBuilder.Build("WIS", inEditStyle, notInEditStyle));
                        break;
                    case AbilityModifier.Int:
                        row.Add(_editableTextBoxBuilder.Build("INT", inEditStyle, notInEditStyle));
                        break;
                    case AbilityModifier.Cha:
                        row.Add(_editableTextBoxBuilder.Build("CHA", inEditStyle, notInEditStyle));
                        break;
                }
                if (skill.HasArmourCheckPenalty)
                {
                    row.Add(_editableTextBoxBuilder.Build(skill.ArmourCheckPenalty.ToString(), inEditStyle, notInEditStyle));
                }
                output.Add(row);
            }
            return output;
        }
    }
}
