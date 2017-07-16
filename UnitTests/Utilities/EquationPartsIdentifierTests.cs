using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Utilities.Implementation.Calculator;

namespace UnitTests.Utilities
{
    [TestFixture]
    class EquationPartsIdentifierTests
    {
        private EquationPartsIdentifier _equationPartsIdentifier;

        [SetUp]
        public void Setup()
        {
            _equationPartsIdentifier = new EquationPartsIdentifier();
        }

        [Test]
        public void FindParts_FindsSingleCharInt()
        {
            var result =_equationPartsIdentifier.FindParts("1");

            result.Should().BeEquivalentTo(new List<string> { "1" });
        }

        [Test]
        public void FindParts_ExtraWhiteSpace_ReturnsCorrectly()
        {
            var result = _equationPartsIdentifier.FindParts("    1");

            result.Should().BeEquivalentTo(new List<string> { "1" });
        }

        [Test]
        public void FindParts_MultipleCharNumber_ReturnsCorrectly()
        {
            var result = _equationPartsIdentifier.FindParts("11");

            result.Should().BeEquivalentTo(new List<string> { "11" });
        }

        [Test]
        public void FindParts_HasOperator_ReturnsTwoParts()
        {
            var result = _equationPartsIdentifier.FindParts("1 +");

            result.Should().BeEquivalentTo(new List<string> { "1", "+" });
        }

        [Test]
        public void FindParts_HasTwoOperators_ReturnsThreeParts()
        {
            var result = _equationPartsIdentifier.FindParts("1 + +");

            result.Should().BeEquivalentTo(new List<string> { "1", "+", "+" });
        }

        [Test]
        public void FindParts_FullEquation_ReturnsCorrectly()
        {
            var result = _equationPartsIdentifier.FindParts("123 + {23 + 4) * {{{22^2111111}}}");

            result.Should().BeEquivalentTo(new List<string> { "123", "+", "{", "23", "+", "4", ")", "*", "{", "{", "{", "22", "^", "2111111", "}", "}", "}"});
        }
    }
}
