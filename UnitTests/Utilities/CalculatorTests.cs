using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Utilities.DTOs;
using Utilities.Implementation.Calculator;
using Utilities.Interfaces;

namespace UnitTests.Utilities
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;
        private IMathsResolver _mathsResolver;
        private INestingIdentifier _nestingIdentifier;

        [SetUp]
        public void Setup()
        {
            _mathsResolver = A.Fake<IMathsResolver>();
            _nestingIdentifier = A.Fake<INestingIdentifier>();
            _calculator = new Calculator(_mathsResolver, _nestingIdentifier);
        }

        [Test]
        public void Calculate_NoBrackets_ReturnsDirectCalculation()
        {
            var equation = "1";
            StringRange deepestNest = null;
            var section = "1";
            A.CallTo(() => _nestingIdentifier.FindDeepestNest(equation)).Returns(deepestNest);
            A.CallTo(() => _mathsResolver.ResolveSection(section)).Returns("1");

            var response = _calculator.Calculate(equation);

            response.Should().Be(1);
            A.CallTo(() => _nestingIdentifier.FindDeepestNest(equation)).MustHaveHappened();
            A.CallTo(() => _mathsResolver.ResolveSection(section)).MustHaveHappened();
        }

        [Test]
        public void Calculate_OneSetOfBrackets_PerformsCorrectCalls()
        {
            var equation = "1+{2+3}";
            var deepestNest1 = new StringRange() {StartIndex = 2, Length = 5};
            var parts1 = "2+3";
            A.CallTo(() => _nestingIdentifier.FindDeepestNest(equation)).Returns(deepestNest1);
            A.CallTo(() => _mathsResolver.ResolveSection(parts1)).Returns("5");

            var equation2 = "1+5";
            StringRange deepestNest2 = null;
            A.CallTo(() => _nestingIdentifier.FindDeepestNest(equation2)).Returns(deepestNest2);
            A.CallTo(() => _mathsResolver.ResolveSection(equation2)).Returns("6");

            var response = _calculator.Calculate(equation);

            response.Should().Be(6);
            A.CallTo(() => _nestingIdentifier.FindDeepestNest(equation)).MustHaveHappened();
            A.CallTo(() => _mathsResolver.ResolveSection(parts1)).MustHaveHappened();
            A.CallTo(() => _nestingIdentifier.FindDeepestNest(equation2)).MustHaveHappened();
            A.CallTo(() => _mathsResolver.ResolveSection(equation2)).MustHaveHappened();
        }
    }
}
