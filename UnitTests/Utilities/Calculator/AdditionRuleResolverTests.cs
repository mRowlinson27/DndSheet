using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Utilities.Implementation.Calculator;

namespace UnitTests.Utilities.Calculator
{
    [TestFixture]
    public class AdditionRuleResolverTests
    {
        private AdditionRuleResolver _additionResolver;

        [SetUp]
        public void Setup()
        {
            _additionResolver = new AdditionRuleResolver();
        }

        [Test]
        public void BothPositiveResolution_PerformedCorrectly()
        {
            var input = new List<string>()
            {
                "1",
                "+",
                "1"
            };

            var value = _additionResolver.BothPositiveResolution(input, 1);

            value.Should().BeEquivalentTo("2");
        }

        [Test]
        public void BothNegativeResolution_PerformedCorrectly()
        {
            var input = new List<string>()
            {
                "-",
                "1",
                "+",
                "-",
                "1"
            };

            var value = _additionResolver.BothNegativeResolution(input, 2);

            value.Should().BeEquivalentTo("-2");
        }

        [Test]
        public void FirstTermNegativeResolution_PerformedCorrectly()
        {
            var input = new List<string>()
            {
                "-",
                "1",
                "+",
                "1"
            };

            var value = _additionResolver.FirstTermNegativeResolution(input, 2);

            value.Should().BeEquivalentTo("0");
        }

        [Test]
        public void SecondTermNegativeResolution_PerformedCorrectly()
        {
            var input = new List<string>()
            {
                "1",
                "+",
                "-",
                "1"
            };

            var value = _additionResolver.SecondTermNegativeResolution(input, 1);

            value.Should().BeEquivalentTo("0");
        }
    }
}
