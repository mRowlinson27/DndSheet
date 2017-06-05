using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API;
using CustomForms.API.Builders;
using CustomForms.DTOs;

namespace CustomForms
{
    public class DataEntryFormManager : IControl
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

        public DataEntryFormManager(ITableLayoutBuilder builder)
        {
            _dataEntryForm = builder.Create(SkillTransform(_skills));
            TrueControl = _dataEntryForm.TrueControl;
        }

        public List<List<string>> SkillTransform(List<SkillsDto> skillsDto)
        {
            var output = new List<List<string>>();
            foreach (var skill in skillsDto)
            {
                var row = new List<string>();
                row.Add(skill.SkillRanks.ToString());
                row.Add(skill.SkillName);
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
                
                output.Add(row);
            }
            return output;
        }
    }
}
