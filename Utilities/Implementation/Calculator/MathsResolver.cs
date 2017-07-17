using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Utilities.Interfaces;
using Utilities.Interfaces.Calculator;

namespace Utilities.Implementation.Calculator
{
    public class MathsResolver : IMathsResolver
    {
        private readonly IEquationPartsIdentifier _equationPartsIdentifier;
        private readonly List<IMathsRuleResolver> _mathsRuleResolvers;

        public MathsResolver(IEquationPartsIdentifier equationPartsIdentifier, List<IMathsRuleResolver> mathsRuleResolvers)
        {
            _equationPartsIdentifier = equationPartsIdentifier;
            _mathsRuleResolvers = mathsRuleResolvers;
        }

        public string ResolveSection(string equation)
        {
            var equationList = _equationPartsIdentifier.FindParts(equation);

            equationList = _mathsRuleResolvers.Aggregate(equationList, ResolveGeneric);

            return equationList.First();
        }

        private List<string> ResolveGeneric(List<string> equationList, IMathsRuleResolver mathsRuleResolver)
        {
            while (equationList.Contains(mathsRuleResolver.Operator))
            {
                var i = 0;
                while (i < equationList.Count)
                {
                    if (equationList[i] == mathsRuleResolver.Operator)
                    {
                        if (FirstTermIsNegative(equationList, i) && SecondTermIsNegative(equationList, i))
                        {
                            equationList[i - 2] = mathsRuleResolver.BothNegativeResolution(equationList, i);
                            equationList.RemoveRange(i - 1, 4);
                        }
                        else if (FirstTermIsNegative(equationList, i))
                        {
                            equationList[i - 2] = mathsRuleResolver.FirstTermNegativeResolution(equationList, i);
                            equationList.RemoveRange(i - 1, 3);
                        }
                        else if (SecondTermIsNegative(equationList, i))
                        {
                            equationList[i - 1] = mathsRuleResolver.SecondTermNegativeResolution(equationList, i);
                            equationList.RemoveRange(i, 3);
                        }
                        else if (i == 0)
                        {
                            equationList[i] = mathsRuleResolver.BothPositiveResolution(equationList, i);
                            equationList.RemoveRange(i + 1, 1);
                        }
                        else
                        {
                            equationList[i - 1] = mathsRuleResolver.BothPositiveResolution(equationList, i);
                            equationList.RemoveRange(i, 2);
                        }
                        i = equationList.Count;
                    }
                    i++;
                }
            }
            return equationList;
        }

        private bool FirstTermIsNegative(List<string> input, int index)
        {
            if (index > 1 && input[index-2] == "-")
            {
                return true;
            }
            return false;
        }

        private bool SecondTermIsNegative(List<string> input, int index)
        {
            if (index < input.Count && input[index + 1] == "-")
            {
                return true;
            }
            return false;
        }
    }
}
