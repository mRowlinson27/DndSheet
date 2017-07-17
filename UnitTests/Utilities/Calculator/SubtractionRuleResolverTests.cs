using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Utilities.Implementation.Calculator;

namespace UnitTests.Utilities.Calculator
{
    [TestFixture]
    public class SubtractionRuleResolverTests
    {
        private SubtractionRuleResolver _subtractionResolver;

        [SetUp]
        public void Setup()
        {
            _subtractionResolver = new SubtractionRuleResolver();
        }

        [Test]
        public void BothPositiveResolution_PerformedCorrectly()
        {
            var input = new List<string>()
            {
                "4",
                "-",
                "2"
            };

            var value = _subtractionResolver.BothPositiveResolution(input, 1);

            value.Should().BeEquivalentTo("2");
        }

        [Test]
        public void BothPositiveResolution_NoFirstTerm_PerformedCorrectly()
        {
            var input = new List<string>()
            {
                "-",
                "2"
            };

            var value = _subtractionResolver.BothPositiveResolution(input, 0);

            value.Should().BeEquivalentTo("-2");
        }

        [Test]
        public void BothNegativeResolution_PerformedCorrectly()
        {
            var input = new List<string>()
            {
                "-",
                "8",
                "-",
                "-",
                "4"
            };

            var value = _subtractionResolver.BothNegativeResolution(input, 2);

            value.Should().BeEquivalentTo("-4");
        }

        [Test]
        public void FirstTermNegativeResolution_PerformedCorrectly()
        {
            var input = new List<string>()
            {
                "-",
                "4",
                "-",
                "2"
            };

            var value = _subtractionResolver.FirstTermNegativeResolution(input, 2);

            value.Should().BeEquivalentTo("-6");
        }

        [Test]
        public void SecondTermNegativeResolution_PerformedCorrectly()
        {
            var input = new List<string>()
            {
                "4",
                "-",
                "-",
                "2"
            };

            var value = _subtractionResolver.SecondTermNegativeResolution(input, 1);

            value.Should().BeEquivalentTo("6");
        }
    }
}
