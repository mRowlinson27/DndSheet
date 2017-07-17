using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Interfaces.Calculator;

namespace Utilities.Implementation.Calculator
{
    public class MathsRuleResolverFactory : IMathsRuleResolverFactory
    {
        public IMathsRuleResolver CreateAdditionRule()
        {
            return new AdditionRuleResolver();
        }

        public IMathsRuleResolver CreateDivisionRule()
        {
            return new DivisionRuleResolver();
        }

        public IMathsRuleResolver CreateMultiplicationRule()
        {
            return new MultiplicationRuleResolver();
        }

        public IMathsRuleResolver CreatePowersRule()
        {
            return new PowersRuleResolver();
        }

        public IMathsRuleResolver CreateSubtractionRule()
        {
            return new SubtractionRuleResolver();
        }
    }
}
