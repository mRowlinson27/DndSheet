using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Interfaces.Calculator;

namespace Utilities.Implementation.Calculator
{
    public class MathsResolverFactory : IMathsResolverFactory
    {
        private readonly IEquationPartsIdentifier _equationPartsIdentifier;

        public MathsResolverFactory(IEquationPartsIdentifier equationPartsIdentifier)
        {
            _equationPartsIdentifier = equationPartsIdentifier;
        }

        public IMathsResolver Create(List<IMathsRuleResolver> mathsRuleResolvers)
        {
            return new MathsResolver(_equationPartsIdentifier, mathsRuleResolvers);
        }
    }
}
