using System.Collections.Generic;

namespace Utilities.Interfaces.Calculator
{
    public interface IMathsRuleResolver
    {
        string Operator { get; }
        string BothPositiveResolution(List<string> input, int index);
        string BothNegativeResolution(List<string> input, int index);
        string FirstTermNegativeResolution(List<string> input, int index);
        string SecondTermNegativeResolution(List<string> input, int index);
    }
}
