using System.Collections.Generic;

namespace Utilities.Interfaces.Calculator
{
    public interface IMathsResolverFactory
    {
        IMathsResolver Create(List<IMathsRuleResolver> mathsRuleResolvers);
    }
}
