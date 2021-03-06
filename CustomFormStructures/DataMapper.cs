﻿using System.Collections.Generic;
using CustomFormManipulation.API;
using CustomForms.API;
using CustomForms.API.Factories;
using CustomFormStructures.API;
using CustomFormStructures.API.Builders;
using DataManipulation.API.DTOs;

namespace CustomFormStructures
{
    public class DataMapper : IDataMapper
    {
        private IEditableTextBoxBuilder _editableTextBoxBuilder;
        private IControlPropertiesFactory _controlPropertiesFactory;

        public DataMapper(IEditableTextBoxBuilder editableTextBoxBuilder, IControlPropertiesFactory controlPropertiesFactory)
        {
            _editableTextBoxBuilder = editableTextBoxBuilder;
            _controlPropertiesFactory = controlPropertiesFactory;
        }

        public List<List<ITrueControl>> SkillDtoToIcontrol(List<SkillsDto> skillsDto)
        {
            var inEditStyle = _controlPropertiesFactory.CreateTextboxInEditStyle();
            var regularStyle = _controlPropertiesFactory.CreateTextboxRegularStyle();
            var output = new List<List<ITrueControl>>();
            foreach (var skill in skillsDto)
            {
                var row = new List<ITrueControl>();
                row.Add(_editableTextBoxBuilder.Build(skill.SkillName, regularStyle, inEditStyle));
                if (skill.Trained)
                {
                    row.Add(_editableTextBoxBuilder.Build("x", regularStyle, inEditStyle));
                }
                else
                {
                    row.Add(_editableTextBoxBuilder.Build("o", regularStyle, inEditStyle));
                }

                row.Add(_editableTextBoxBuilder.Build(skill.SkillRanks.ToString(), regularStyle, inEditStyle));
                switch (skill.Modifier)
                {
                    case AbilityModifier.Str:
                        row.Add(_editableTextBoxBuilder.Build("STR", regularStyle, inEditStyle));
                        break;
                    case AbilityModifier.Dex:
                        row.Add(_editableTextBoxBuilder.Build("DEX", regularStyle, inEditStyle));
                        break;
                    case AbilityModifier.Con:
                        row.Add(_editableTextBoxBuilder.Build("CON", regularStyle, inEditStyle));
                        break;
                    case AbilityModifier.Wis:
                        row.Add(_editableTextBoxBuilder.Build("WIS", regularStyle, inEditStyle));
                        break;
                    case AbilityModifier.Int:
                        row.Add(_editableTextBoxBuilder.Build("INT", regularStyle, inEditStyle));
                        break;
                    case AbilityModifier.Cha:
                        row.Add(_editableTextBoxBuilder.Build("CHA", regularStyle, inEditStyle));
                        break;
                }
                if (skill.HasArmourCheckPenalty)
                {
                    row.Add(_editableTextBoxBuilder.Build(skill.ArmourCheckPenalty.ToString(), regularStyle, inEditStyle));
                }
                output.Add(row);
            }
            return output;
        }
    }
}
