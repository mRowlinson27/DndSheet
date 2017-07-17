using Utilities.DTOs;

namespace Utilities.Interfaces.Calculator
{
    public interface INestingIdentifier
    {
        StringRange FindDeepestNest(string equation);
    }
}
