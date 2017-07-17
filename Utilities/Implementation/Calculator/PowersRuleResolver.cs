using System;
using System.Collections.Generic;
using Utilities.Interfaces;
using Utilities.Interfaces.Calculator;

namespace Utilities.Implementation.Calculator
{
    public class PowersRuleResolver : IMathsRuleResolver
    {
        public PowersRuleResolver()
        {
            Operator = "^";
        }
        public string Operator { get; }
        public string BothPositiveResolution(List<string> input, int index)
        {
            return ((int)Math.Pow(int.Parse(input[index - 1]), int.Parse(input[index + 1]))).ToString();
        }

        public string BothNegativeResolution(List<string> input, int index)
        {
            throw new NotImplementedException();
        }

        public string FirstTermNegativeResolution(List<string> input, int index)
        {
            return ((int)Math.Pow(-int.Parse(input[index - 1]), int.Parse(input[index + 1]))).ToString();
        }

        public string SecondTermNegativeResolution(List<string> input, int index)
        {
            throw new NotImplementedException();
        }
    }
}
