using System;
using System.Collections.Generic;
using Utilities.Interfaces;

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
            return result;
        }

        private string RemoveWhiteSpace(string equation)
        {
            return equation.Replace(" ", String.Empty);
        }
    }
}
