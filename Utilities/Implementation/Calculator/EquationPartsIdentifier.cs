using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Interfaces;
using Utilities.Interfaces.Calculator;

namespace Utilities.Implementation.Calculator
{
    public class EquationPartsIdentifier : IEquationPartsIdentifier
    {
        public List<string> FindParts(string equation)
        {
            var result = new List<string>();
            equation = RemoveWhiteSpace(equation);

            var current = -1;
            var lastWasDigit = false;
            foreach (var character in equation)
            {
                if (char.IsDigit(character))
                {
                    if (lastWasDigit)
                    {
                        result[current] += character;
                    }
                    else
                    {
                        result.Add(character.ToString());
                        lastWasDigit = true;
                        current++;
                    }
                }
                else
                {
                    result.Add(character.ToString());
                    lastWasDigit = false;
                    current++;
                }
            }
            for (var i = result.Count-2; i > 0; i--)
            {
                if (result[i] == "-" && i <= result.Count - 2 && result[i + 1] == "+")
                {
                    result.RemoveAt(i + 1);
                }
                if (result[i] == "-" && i <= result.Count - 2 && result[i + 1] == "-")
                {
                    result.RemoveAt(i + 1);
                    result[i] = "+";
                }
                if (result[i] == "+" && i <= result.Count - 2 && result[i + 1] == "+")
                {
                    result.RemoveAt(i);
                }
                if (result[i] == "+" && i <= result.Count - 2 && result[i + 1] == "-")
                {
                    result.RemoveAt(i);
                }
            }
            return result;
        }

        private string RemoveWhiteSpace(string equation)
        {
            return equation.Replace(" ", String.Empty);
        }
    }
}
