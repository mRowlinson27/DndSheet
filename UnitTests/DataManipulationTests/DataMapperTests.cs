using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms;
using CustomForms.API;
using CustomForms.API.Factories;
using CustomForms.Factories;
using DataManipulation;
using DataManipulation.API.DTOs;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    class DataMapperTests
    {
        private DataMapper _dataMapper;
        private IEditableTextBoxFactory _editableTextBoxFactory;

        [SetUp]
        public void Setup()
        {
            _editableTextBoxFactory = new EditableTextBoxFactory(new LabelWrapperFactory());
            _dataMapper = new DataMapper(_editableTextBoxFactory);
        }

        [Test]
        public void SkillDtoToIControl_CorrectList()
        {
            var skills = new List<SkillsDto>
            {
                new SkillsDto()
                {
                    SkillName = "Acrobatics",
                    SkillRanks = 1,
                    HasArmourCheckPenalty = true,
                    ArmourCheckPenalty = 0,
                    Modifier = AbilityModifier.Dex,
                    UseUntrained = true,
                    Trained = true
                },
                new SkillsDto()
                {
                    SkillName = "Appraise",
                    SkillRanks = 0,
                    HasArmourCheckPenalty = false,
                    Modifier = AbilityModifier.Int,
                    UseUntrained = true,
                    Trained = false
                },
                new SkillsDto()
                {
                    SkillName = "Bluff",
                    SkillRanks = 3,
                    HasArmourCheckPenalty = false,
                    Modifier = AbilityModifier.Cha,
                    UseUntrained = true,
                    Trained = false
                }
            };
            var result = _dataMapper.SkillDtoToIcontrol(skills);

            result[0].Count.Should().Be(5);
            (result[0][0] as ILabelWrapper).Text.Should().Be("Acrobatics");
            (result[0][1] as ILabelWrapper).Text.Should().Be("x");
            (result[0][2] as ILabelWrapper).Text.Should().Be("1");
            (result[0][3] as ILabelWrapper).Text.Should().Be("DEX");
            (result[0][4] as ILabelWrapper).Text.Should().Be("0");

            result[1].Count.Should().Be(4);
            (result[1][0] as ILabelWrapper).Text.Should().Be("Appraise");
            (result[1][1] as ILabelWrapper).Text.Should().Be("o");
            (result[1][2] as ILabelWrapper).Text.Should().Be("0");
            (result[1][3] as ILabelWrapper).Text.Should().Be("INT");

            result[2].Count.Should().Be(4);
            (result[2][0] as ILabelWrapper).Text.Should().Be("Bluff");
            (result[2][1] as ILabelWrapper).Text.Should().Be("o");
            (result[2][2] as ILabelWrapper).Text.Should().Be("3");
            (result[2][3] as ILabelWrapper).Text.Should().Be("CHA");
        }
    }
}
