using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API;
using CustomForms.API.Builders;
using DataManipulation.API;
using DataManipulation.API.DTOs;

namespace CustomForms
{
    public class DataEntryFormManager : IDataEntryFormManager
    {
        private List<SkillsDto> _skills = new List<SkillsDto>
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

        private IDataEntryForm _dataEntryForm;

        public Control TrueControl { get; set; }
        public event EventHandler Click;

        public DataEntryFormManager(ITableLayoutBuilder builder, IDataMapper dataMapper)
        {
            _dataEntryForm = builder.Create(dataMapper.SkillDtoToStringsList(_skills));
            TrueControl = _dataEntryForm.TrueControl;
        }
    }
}
