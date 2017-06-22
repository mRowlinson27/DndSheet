using System.Collections.Generic;
using System.Windows.Forms;
using CustomFormManipulation.API;
using CustomForms.API;
using CustomForms.API.DTOs;
using CustomFormStructures.API;
using CustomFormStructures.API.Builders;
using DataManipulation.API;
using DataManipulation.API.DTOs;

namespace CustomFormStructures
{
    public class DataEntryFormManager : IDataEntryFormManager
    {
        public EditableStatus EditableStatus
        {
            get { return _dataEntryForm.EditableStatus; }
            set { _dataEntryForm.EditableStatus = value; }
        }

        public ITrueControl GetControl(int row, int col)
        {
            return _dataEntryForm.GetControl(row, col);
;        }

        private List<SkillsDto> _skills = new List<SkillsDto>
        {
            new SkillsDto()
            {
                SkillName = "Acrobatics",
                SkillRanks = 0,
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
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Cha,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Climb",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Str,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Diplomacy",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Cha,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Disable Device",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Dex,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Disguise",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Cha,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Escape Artist",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Dex,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Fly",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Dex,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Handle Animal",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Cha,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Heal",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Wis,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Intimidate",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Cha,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Linguistics",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Int,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Perception",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Wis,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Ride",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Dex,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Sense Motive",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Wis,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Sleight of Hand",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Dex,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Spellcraft",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Int,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Stealth",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Dex,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Survival",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Wis,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Swim",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Str,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Use Magic Device",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Cha,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Knowledge (arcana)",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Int,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Knowledge (dungeoneering)",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Int,
                UseUntrained = true,
                Trained = false
            },new SkillsDto()
            {
                SkillName = "Knowledge (engineering)",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Int,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Knowledge (geography)",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Int,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Knowledge (history)",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Int,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Knowledge (local)",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Int,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Knowledge (nature)",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Int,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Knowledge (nobility)",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Int,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Knowledge (planes)",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Int,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Knowledge (religion)",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Int,
                UseUntrained = true,
                Trained = false
            },
            new SkillsDto()
            {
                SkillName = "Profession",
                SkillRanks = 0,
                HasArmourCheckPenalty = false,
                Modifier = AbilityModifier.Wis,
                UseUntrained = true,
                Trained = false
            }
        };

        private IDataEntryForm _dataEntryForm;

        public Control TrueControl { get; set; }
        
        public DataEntryFormManager(IDataEntryFormBuilder dataEntryFormBuilder, IDataMapper dataMapper)
        {
            _dataEntryForm = dataEntryFormBuilder.Build(dataMapper.SkillDtoToIcontrol(_skills));
            TrueControl = _dataEntryForm.TrueControl;
        }
    }
}
