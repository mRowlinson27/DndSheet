using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Utilities.Implementation.Calculator;
using Utilities.Interfaces.Calculator;

namespace UnitTests.Utilities.Calculator
{
    [TestFixture]
    public class MathsResolverTests
    {
        private MathsResolver _mathsResolver;
        private IEquationPartsIdentifier _equationPartsIdentifier;
        private IMathsRuleResolver _mathsRuleResolver;

        [SetUp]
        public void Setup()
        {
            _equationPartsIdentifier = A.Fake<IEquationPartsIdentifier>();
            _mathsRuleResolver = A.Fake<IMathsRuleResolver>();
            _mathsResolver = new MathsResolver(_equationPartsIdentifier,
                new List<IMathsRuleResolver> {_mathsRuleResolver});
        }

        [Test]
        public void BothPositiveResolution_PerformedCorrectly()
        {
            var equation = "1+1";
            var input = new List<string>()
            {
                "1",
                "+",
                "1"
            };
            A.CallTo(() => _mathsRuleResolver.Operator).Returns("+");
            A.CallTo(() => _mathsRuleResolver.BothPositiveResolution(input, 1)).Returns("2");
            A.CallTo(() => _equationPartsIdentifier.FindParts(equation)).Returns(input);

            var response = _mathsResolver.ResolveSection(equation);

            response.Should().Be("+2");
            A.CallTo(() => _equationPartsIdentifier.FindParts(equation)).MustHaveHappened();
            A.CallTo(() => _mathsRuleResolver.BothPositiveResolution(input, 1)).MustHaveHappened();
        }

        [Test]
        public void BothPositiveResolution_Implied0_PerformedCorrectly()
        {
            var equation = "-1";
            var input = new List<string>()
            {
                "-",
                "1"
            };
            A.CallTo(() => _mathsRuleResolver.Operator).Returns("-");
            A.CallTo(() => _mathsRuleResolver.BothPositiveResolution(input, 0)).Returns("-1");
            A.CallTo(() => _equationPartsIdentifier.FindParts(equation)).Returns(input);

            var response = _mathsResolver.ResolveSection(equation);

            response.Should().Be("-1");
            A.CallTo(() => _equationPartsIdentifier.FindParts(equation)).MustHaveHappened();
            A.CallTo(() => _mathsRuleResolver.BothPositiveResolution(input, 0)).MustHaveHappened();
        }

        [Test]
        public void BothNegativeResolution_PerformedCorrectly()
        {
            var equation = "-1+-1";
            var input = new List<string>()
            {
                "-",
                "1",
                "+",
                "-",
                "1"
            };
            A.CallTo(() => _mathsRuleResolver.Operator).Returns("+");
            A.CallTo(() => _mathsRuleResolver.BothNegativeResolution(input, 2)).Returns("2");
            A.CallTo(() => _equationPartsIdentifier.FindParts(equation)).Returns(input);

            var response = _mathsResolver.ResolveSection(equation);

            response.Should().Be("+2");
            A.CallTo(() => _equationPartsIdentifier.FindParts(equation)).MustHaveHappened();
            A.CallTo(() => _mathsRuleResolver.BothNegativeResolution(input, 2)).MustHaveHappened();
        }

        [Test]
        public void FirstTermNegativeResolution_PerformedCorrectly()
        {
            var equation = "1+1";
            var input = new List<string>()
            {
                "-",
                "1",
                "+",
                "1"
            };
            A.CallTo(() => _mathsRuleResolver.Operator).Returns("+");
            A.CallTo(() => _mathsRuleResolver.FirstTermNegativeResolution(input, 2)).Returns("2");
            A.CallTo(() => _equationPartsIdentifier.FindParts(equation)).Returns(input);

            var response = _mathsResolver.ResolveSection(equation);

            response.Should().Be("+2");
            A.CallTo(() => _equationPartsIdentifier.FindParts(equation)).MustHaveHappened();
            A.CallTo(() => _mathsRuleResolver.FirstTermNegativeResolution(input, 2)).MustHaveHappened();

        }

        [Test]
        public void SecondTermNegativeResolution_PerformedCorrectly()
        {
            var equation = "1+1";
            var input = new List<string>()
            {
                "1",
                "+",
                "-",
                "1"
            };
            A.CallTo(() => _mathsRuleResolver.Operator).Returns("+");
            A.CallTo(() => _mathsRuleResolver.SecondTermNegativeResolution(input, 1)).Returns("2");
            A.CallTo(() => _equationPartsIdentifier.FindParts(equation)).Returns(input);

            var response = _mathsResolver.ResolveSection(equation);

            response.Should().Be("+2");
            A.CallTo(() => _equationPartsIdentifier.FindParts(equation)).MustHaveHappened();
            A.CallTo(() => _mathsRuleResolver.SecondTermNegativeResolution(input, 1)).MustHaveHappened();
        }
    }
}
