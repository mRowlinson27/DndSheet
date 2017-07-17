using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Utilities.Implementation.Calculator;

namespace UnitTests.Utilities.Calculator
{
    [TestFixture]
    public class MultiplicationRuleResolverTests
    {
        private MultiplicationRuleResolver _multiplicationResolver;

        [SetUp]
        public void Setup()
        {
            _multiplicationResolver = new MultiplicationRuleResolver();
        }

        [Test]
        public void BothPositiveResolution_PerformedCorrectly()
        {
            var input = new List<string>()
            {
                "2",
                "*",
                "2"
            };

            var value = _multiplicationResolver.BothPositiveResolution(input, 1);

            value.Should().BeEquivalentTo("4");
        }

        [Test]
        public void BothNegativeResolution_PerformedCorrectly()
        {
            var input = new List<string>()
            {
                "-",
                "2",
                "*",
                "-",
                "4"
            };

            var value = _multiplicationResolver.BothNegativeResolution(input, 2);

            value.Should().BeEquivalentTo("8");
        }

        [Test]
        public void FirstTermNegativeResolution_PerformedCorrectly()
        {
            var input = new List<string>()
            {
                "-",
                "2",
                "*",
                "4"
            };

            var value = _multiplicationResolver.FirstTermNegativeResolution(input, 2);

            value.Should().BeEquivalentTo("-8");
        }

        [Test]
        public void SecondTermNegativeResolution_PerformedCorrectly()
        {
            var input = new List<string>()
            {
                "2",
                "*",
                "-",
                "4"
            };

            var value = _multiplicationResolver.SecondTermNegativeResolution(input, 1);

            value.Should().BeEquivalentTo("-8");
        }
    }
}
