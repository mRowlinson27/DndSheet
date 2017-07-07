using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulation.API.DTOs
{
    public class AbilityScore
    {
        public string Name { get; set; }
        public string Abr { get; set; }
        public int Value { get; set; }
        public int Mod { get; private set; }

        private SqlAbilityScore _sqlAbilityScore;

        public AbilityScore(SqlAbilityScore sqlAbilityScore)
        {
            _sqlAbilityScore = sqlAbilityScore;
        }

        public void Update()
        {
            Mod = (Value - 10)/2;
        }
    }
}
