using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Utilities.Implementation.Calculator;

namespace UnitTests.Utilities.Calculator
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
        public void FindParts_HasTwoPlusOperators_ReturnsOne()
        {
            var result = _equationPartsIdentifier.FindParts("1 + +");

            result.Should().BeEquivalentTo(new List<string> { "1", "+" });
        }

        [Test]
        public void FindParts_HasTwoNegOperators_ReturnsOne()
        {
            var result = _equationPartsIdentifier.FindParts("1 - -");

            result.Should().BeEquivalentTo(new List<string> { "1", "+" });
        }

        [Test]
        public void FindParts_HasNegThenPosOperators_ReturnsNeg()
        {
            var result = _equationPartsIdentifier.FindParts("1 - +");

            result.Should().BeEquivalentTo(new List<string> { "1", "-" });
        }

        [Test]
        public void FindParts_HasPosThenNegOperators_ReturnsNeg()
        {
            var result = _equationPartsIdentifier.FindParts("1 + -");

            result.Should().BeEquivalentTo(new List<string> { "1", "-" });
        }

        [Test]
        public void FindParts_HasLongSequenceOperator_ReturnsOne()
        {
            var result = _equationPartsIdentifier.FindParts("1 +++++++-");

            result.Should().BeEquivalentTo(new List<string> { "1", "-" });
        }

        [Test]
        public void FindParts_FullEquation_ReturnsCorrectly()
        {
            var result = _equationPartsIdentifier.FindParts("123 + {23 + 4) * {{{22^2111111}}}");

            result.Should().BeEquivalentTo(new List<string> { "123", "+", "{", "23", "+", "4", ")", "*", "{", "{", "{", "22", "^", "2111111", "}", "}", "}"});
        }
    }
}
