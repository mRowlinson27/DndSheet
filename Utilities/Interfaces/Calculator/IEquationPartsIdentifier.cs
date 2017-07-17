using System.Collections.Generic;

namespace Utilities.Interfaces.Calculator
{
    public interface IEquationPartsIdentifier
    {
        List<string> FindParts(string equation);
    }
}
