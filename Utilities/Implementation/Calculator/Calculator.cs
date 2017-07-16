using System;
using Utilities.API;
using Utilities.DTOs;
using Utilities.Interfaces;

namespace Utilities.Implementation.Calculator
{
    public class Calculator : ICalculator
    {
        private readonly IMathsResolver _mathsResolver;
        private readonly INestingIdentifier _nestingIdentifier;

        public Calculator(IMathsResolver mathsResolver, INestingIdentifier nestingIdentifier)
        {
            _mathsResolver = mathsResolver;
            _nestingIdentifier = nestingIdentifier;
        }

        public int Calculate(string equation)
        {
            var value = 0;
            var range = _nestingIdentifier.FindDeepestNest(equation);
            while (range != null)
            {
                var nest = equation.Substring(range.StartIndex + 1, range.Length - 2);
                var resolvedNest = _mathsResolver.ResolveSection(nest);
                equation = equation.Remove(range.StartIndex, range.Length);
                equation = equation.Insert(range.StartIndex, resolvedNest);
                range = _nestingIdentifier.FindDeepestNest(equation);
            }

            return Int32.Parse(_mathsResolver.ResolveSection(equation));
        }
    }
}
