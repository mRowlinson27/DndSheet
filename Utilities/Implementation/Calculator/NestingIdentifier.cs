using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Utilities.DTOs;
using Utilities.Interfaces;
using Utilities.Interfaces.Calculator;

namespace Utilities.Implementation.Calculator
{
    public class NestingIdentifier : INestingIdentifier
    {
        public StringRange FindDeepestNest(string equation)
        {
            var regex = new Regex(@"
    [\(\{\[]                    # Match (
    (
        [^\(\)\{\}\[\]]+            # all chars except ()
        | (?<Level>\()    # or if ( then Level += 1
        | (?<-Level>\))   # or if ) then Level -= 1
    )+                    # Repeat (to go from inside to outside)
    (?(Level)(?!))        # zero-width negative lookahead assertion
    [\)\}\]]                    # Match )", RegexOptions.IgnorePatternWhitespace);

            var matches =  regex.Matches(equation);
            if (matches.Count != 0)
            {
                return new StringRange() { StartIndex = matches[0].Index, Length = matches[0].Length};
            }
            return null;
        }
    }
}
