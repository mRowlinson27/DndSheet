using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Utilities.Implementation.Calculator;

namespace UnitTests.Utilities.Calculator
{
    [TestFixture]
    public class DivisionRuleResolverTests
    {
        private DivisionRuleResolver _divisionResolver;

        [SetUp]
        public void Setup()
        {
            _divisionResolver = new DivisionRuleResolver();
        }

        [Test]
        public void BothPositiveResolution_PerformedCorrectly()
        {
            var input = new List<string>()
            {
                "4",
                "/",
                "2"
            };

            var value = _divisionResolver.BothPositiveResolution(input, 1);

            value.Should().BeEquivalentTo("2");
        }

        [Test]
        public void BothNegativeResolution_PerformedCorrectly()
        {
            var input = new List<string>()
            {
                "-",
                "8",
                "/",
                "-",
                "4"
            };

            var value = _divisionResolver.BothNegativeResolution(input, 2);

            value.Should().BeEquivalentTo("2");
        }

        [Test]
        public void FirstTermNegativeResolution_PerformedCorrectly()
        {
            var input = new List<string>()
            {
                "-",
                "4",
                "/",
                "2"
            };

            var value = _divisionResolver.FirstTermNegativeResolution(input, 2);

            value.Should().BeEquivalentTo("-2");
        }

        [Test]
        public void SecondTermNegativeResolution_PerformedCorrectly()
        {
            var input = new List<string>()
            {
                "4",
                "/",
                "-",
                "2"
            };

            var value = _divisionResolver.SecondTermNegativeResolution(input, 1);

            value.Should().BeEquivalentTo("-2");
        }
    }
}
