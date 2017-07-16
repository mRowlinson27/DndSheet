using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Interfaces;

namespace Utilities.Implementation.Calculator
{
    public class MathsResolver : IMathsResolver
    {
        private readonly IEquationPartsIdentifier _equationPartsIdentifier;

        public MathsResolver(IEquationPartsIdentifier equationPartsIdentifier)
        {
            _equationPartsIdentifier = equationPartsIdentifier;
        }

        public string ResolveSection(string equation)
        {
            var equationList = _equationPartsIdentifier.FindParts(equation);

            equationList = ResolvePowers(equationList);
            equationList = ResolveMultiplication(equationList);
            equationList = ResolveDivision(equationList);
            equationList = ResolveAddition(equationList);
            equationList = ResolveSubtraction(equationList);

            return equationList.First();
        }

        private List<string> ResolveAddition(List<string> equationList)
        {
            while (equationList.Contains("+"))
            {
                var i = 0;
                while (i < equationList.Count)
                {
                    if (equationList[i] == "+")
                    {
                        equationList[i] = (int.Parse(equationList[i - 1]) + int.Parse(equationList[i + 1])).ToString();
                        equationList.RemoveAt(i + 1);
                        equationList.RemoveAt(i - 1);
                        i = equationList.Count;
                    }
                    i++;
                }
            }
            return equationList;
        }

        private List<string> ResolveSubtraction(List<string> equationList)
        {
            while (equationList.Contains("-") && equationList.Count > 1)
            {
                var i = 0;
                while (i < equationList.Count)
                {
                    if (equationList[i] == "-")
                    {
                        if (i > 0)
                        {
                            equationList[i] = (int.Parse(equationList[i - 1]) - int.Parse(equationList[i + 1])).ToString();
                            equationList.RemoveAt(i + 1);
                            equationList.RemoveAt(i - 1);
                        }
                        else
                        {
                            equationList[i] = (0 - int.Parse(equationList[i + 1])).ToString();
                            equationList.RemoveAt(i + 1);
                        }

                        
                        i = equationList.Count;
                    }
                    i++;
                }
            }
            return equationList;
        }

        private List<string> ResolveMultiplication(List<string> equationList)
        {
            while (equationList.Contains("*"))
            {
                var i = 0;
                while (i < equationList.Count)
                {
                    if (equationList[i] == "*")
                    {
                        equationList[i] = (int.Parse(equationList[i - 1]) * int.Parse(equationList[i + 1])).ToString();
                        equationList.RemoveAt(i + 1);
                        equationList.RemoveAt(i - 1);
                        i = equationList.Count;
                    }
                    i++;
                }
            }
            return equationList;
        }

        private List<string> ResolveDivision(List<string> equationList)
        {
            while (equationList.Contains("/"))
            {
                var i = 0;
                while (i < equationList.Count)
                {
                    if (equationList[i] == "/")
                    {
                        equationList[i] = (int.Parse(equationList[i - 1]) / int.Parse(equationList[i + 1])).ToString();
                        equationList.RemoveAt(i + 1);
                        equationList.RemoveAt(i - 1);
                        i = equationList.Count;
                    }
                    i++;
                }
            }
            return equationList;
        }

        private List<string> ResolvePowers(List<string> equationList)
        {
            while (equationList.Contains("^"))
            {
                var i = 0;
                while (i < equationList.Count)
                {
                    if (equationList[i] == "^")
                    {
                        equationList[i] = ((int) Math.Pow(int.Parse(equationList[i - 1]),  int.Parse(equationList[i + 1]))).ToString();
                        equationList.RemoveAt(i + 1);
                        equationList.RemoveAt(i - 1);
                        i = equationList.Count;
                    }
                    i++;
                }
            }
            return equationList;
        }
    }
}
