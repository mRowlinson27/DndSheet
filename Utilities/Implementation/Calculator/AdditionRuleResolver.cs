using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Interfaces;
using Utilities.Interfaces.Calculator;

namespace Utilities.Implementation.Calculator
{
    public class AdditionRuleResolver : IMathsRuleResolver
    {
        public string Operator { get; }

        public AdditionRuleResolver()
        {
            Operator = "+";
        }

        public string BothPositiveResolution(List<string> input, int index)
        {
            return (int.Parse(input[index - 1]) + int.Parse(input[index + 1])).ToString();
        }

        public string BothNegativeResolution(List<string> input, int index)
        {
            return (-int.Parse(input[index - 1]) - int.Parse(input[index + 2])).ToString();
        }

        public string FirstTermNegativeResolution(List<string> input, int index)
        {
            return (int.Parse(input[index - 1]) - int.Parse(input[index + 1])).ToString();
        }

        public string SecondTermNegativeResolution(List<string> input, int index)
        {
            return (int.Parse(input[index - 1]) - int.Parse(input[index + 2])).ToString();
        }
    }
}
