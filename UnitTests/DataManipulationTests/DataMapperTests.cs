using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [SetUp]
        public void Setup()
        {
            _dataMapper = new DataMapper();
        }

        [Test]
        public void SkillDtoToStringsList_CorrectList()
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

            var correctResult = new List<List<string>>()
            {
                new List<string>()
                {
                    "Acrobatics","x","1","DEX","0"
                },
                new List<string>()
                {
                    "Appraise","o","0","INT"
                },
                new List<string>()
                {
                    "Bluff","o","3","CHA"
                }
            };

            var result = _dataMapper.SkillDtoToStringsList(skills);

            result.ShouldAllBeEquivalentTo(correctResult);
        }
    }
}
