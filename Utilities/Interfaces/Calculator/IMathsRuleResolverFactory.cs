namespace Utilities.Interfaces.Calculator
{
    public interface IMathsRuleResolverFactory
    {
        IMathsRuleResolver CreateAdditionRule();
        IMathsRuleResolver CreateDivisionRule();
        IMathsRuleResolver CreateMultiplicationRule();
        IMathsRuleResolver CreatePowersRule();
        IMathsRuleResolver CreateSubtractionRule();
    }
}
