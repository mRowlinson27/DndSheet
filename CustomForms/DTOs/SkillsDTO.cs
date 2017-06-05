using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API.DTOs;

namespace CustomForms.DTOs
{
    public class SkillsDto
    {
        public string SkillName { get; set; }
        public int SkillRanks { get; set; }
        public AbilityModifier Modifier { get; set; }
        public int ArmourCheckPenalty { get; set; }
        public bool HasArmourCheckPenalty { get; set; }
        public bool UseUntrained { get; set; }
        public bool Trained { get; set; }
    }

    public enum AbilityModifier {Str, Dex, Con, Int, Wis, Cha};
}
