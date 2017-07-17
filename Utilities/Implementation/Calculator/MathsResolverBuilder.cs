using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Interfaces;
using Utilities.Interfaces.Calculator;

namespace Utilities.Implementation.Calculator
{
    public class MathsResolverBuilder : IMathsResolverBuilder
    {
        private readonly IMathsResolverFactory _mathsResolverFactory;
        private readonly IMathsRuleResolverFactory _mathsRuleResolverFactory;

        public MathsResolverBuilder(IMathsResolverFactory mathsResolverFactory, IMathsRuleResolverFactory mathsRuleResolverFactory)
        {
            _mathsResolverFactory = mathsResolverFactory;
            _mathsRuleResolverFactory = mathsRuleResolverFactory;
        }
        public IMathsResolver Build()
        {
            var mathsRules = new List<IMathsRuleResolver>
            {
                _mathsRuleResolverFactory.CreatePowersRule(),
                _mathsRuleResolverFactory.CreateMultiplicationRule(),
                _mathsRuleResolverFactory.CreateDivisionRule(),
                _mathsRuleResolverFactory.CreateAdditionRule(),
                _mathsRuleResolverFactory.CreateSubtractionRule()
            };

            return _mathsResolverFactory.Create(mathsRules);
        }
    }
}
