using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Utilities.Implementation.Calculator;
using Utilities.Interfaces;

namespace UnitTests.Utilities
{
    [TestFixture]
    public class MathsResolverTests
    {
        private MathsResolver _mathsResolver;
        private IEquationPartsIdentifier _equationPartsIdentifier;

        [SetUp]
        public void Setup()
        {
            _equationPartsIdentifier = A.Fake<IEquationPartsIdentifier>();
            _mathsResolver = new MathsResolver(_equationPartsIdentifier);
        }

        [Test]
        public void ResolveSection_SingleNumber_ReturnsItself()
        {
            var input = "123";
            var equationParts = new List<string>()
            {
                "123"
            };
            A.CallTo(() => _equationPartsIdentifier.FindParts(input)).Returns(equationParts);

            var value = _mathsResolver.ResolveSection(input);

            value.Should().Be("123");
        }

        [Test]
        public void ResolveSection_BasicAddition_PerformedCorrectly()
        {
            var input = "1 + 1";
            var equationParts = new List<string>()
            {
                "1",
                "+",
                "1"
            };
            A.CallTo(() => _equationPartsIdentifier.FindParts(input)).Returns(equationParts);

            var value = _mathsResolver.ResolveSection(input);

            value.Should().Be("2");
        }

        [Test]
        public void ResolveSection_BasicSubtraction_PerformedCorrectly()
        {
            var input = "2 - 1";
            var equationParts = new List<string>()
            {
                "2",
                "-",
                "1"
            };
            A.CallTo(() => _equationPartsIdentifier.FindParts(input)).Returns(equationParts);

            var value = _mathsResolver.ResolveSection(input);

            value.Should().Be("1");
        }

        [Test]
        public void ResolveSection_ImplicitSubtraction_PerformedCorrectly()
        {
            var input = "2 - 1";
            var equationParts = new List<string>()
            {
                "-",
                "1"
            };
            A.CallTo(() => _equationPartsIdentifier.FindParts(input)).Returns(equationParts);

            var value = _mathsResolver.ResolveSection(input);

            value.Should().Be("-1");
        }

        [Test]
        public void ResolveSection_AddingToNegatives_PerformedCorrectly()
        {
            var input = "50 - 36 + 2";
            var equationParts = new List<string>()
            {
                "50",
                "-",
                "36",
                "+",
                "2"
            };
            A.CallTo(() => _equationPartsIdentifier.FindParts(input)).Returns(equationParts);

            var value = _mathsResolver.ResolveSection(input);

            value.Should().Be("16");
        }

        [Test]
        public void ResolveSection_SubtractionIntoNegatives_PerformedCorrectly()
        {
            var input = "10 - 20";
            var equationParts = new List<string>()
            {
                "10",
                "-",
                "20"
            };
            A.CallTo(() => _equationPartsIdentifier.FindParts(input)).Returns(equationParts);

            var value = _mathsResolver.ResolveSection(input);

            value.Should().Be("-10");
        }

        [Test]
        public void ResolveSection_BasicMultiplication_PerformedCorrectly()
        {
            var input = "2 * 3";
            var equationParts = new List<string>()
            {
                "2",
                "*",
                "3"
            };
            A.CallTo(() => _equationPartsIdentifier.FindParts(input)).Returns(equationParts);

            var value = _mathsResolver.ResolveSection(input);

            value.Should().Be("6");
        }

        [Test]
        public void ResolveSection_BasicDivision_PerformedCorrectly()
        {
            var input = "6 / 3";
            var equationParts = new List<string>()
            {
                "6",
                "/",
                "3"
            };
            A.CallTo(() => _equationPartsIdentifier.FindParts(input)).Returns(equationParts);

            var value = _mathsResolver.ResolveSection(input);

            value.Should().Be("2");
        }

        [Test]
        public void ResolveSection_DivisionRoundsDown_PerformedCorrectly()
        {
            var input = "5 / 2";
            var equationParts = new List<string>()
            {
                "5",
                "/",
                "2"
            };
            A.CallTo(() => _equationPartsIdentifier.FindParts(input)).Returns(equationParts);

            var value = _mathsResolver.ResolveSection(input);

            value.Should().Be("2");
        }

        [Test]
        public void ResolveSection_BasicPowers_PerformedCorrectly()
        {
            var input = "2 ^ 4";
            var equationParts = new List<string>()
            {
                "2",
                "^",
                "4"
            };
            A.CallTo(() => _equationPartsIdentifier.FindParts(input)).Returns(equationParts);

            var value = _mathsResolver.ResolveSection(input);

            value.Should().Be("16");
        }

        [Test]
        public void ResolveSection_MultiplicationHappensBeforeAddition_PerformedCorrectly()
        {
            var input = "2 + 3 * 2";
            var equationParts = new List<string>()
            {
                "2",
                "+",
                "3",
                "*",
                "2"
            };
            A.CallTo(() => _equationPartsIdentifier.FindParts(input)).Returns(equationParts);

            var value = _mathsResolver.ResolveSection(input);

            value.Should().Be("8");
        }

        [Test]
        public void ResolveSection_DivisionHappensBeforeAddition_PerformedCorrectly()
        {
            var input = "2 + 6 / 2";
            var equationParts = new List<string>()
            {
                "2",
                "+",
                "6",
                "/",
                "2"
            };
            A.CallTo(() => _equationPartsIdentifier.FindParts(input)).Returns(equationParts);

            var value = _mathsResolver.ResolveSection(input);

            value.Should().Be("5");
        }

        [Test]
        public void ResolveSection_PowersHappensBeforeMultiplication_PerformedCorrectly()
        {
            var input = "2 * 3 ^ 2";
            var equationParts = new List<string>()
            {
                "2",
                "*",
                "3",
                "^",
                "2"
            };
            A.CallTo(() => _equationPartsIdentifier.FindParts(input)).Returns(equationParts);

            var value = _mathsResolver.ResolveSection(input);

            value.Should().Be("18");
        }

        [Test]
        public void ResolveSection_PowersHappensBeforeDivision_PerformedCorrectly()
        {
            var input = "32 / 4 ^ 2";
            var equationParts = new List<string>()
            {
                "32",
                "/",
                "4",
                "^",
                "2"
            };
            A.CallTo(() => _equationPartsIdentifier.FindParts(input)).Returns(equationParts);

            var value = _mathsResolver.ResolveSection(input);

            value.Should().Be("2");
        }
    }
}
