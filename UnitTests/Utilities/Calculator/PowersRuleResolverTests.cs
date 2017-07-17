using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Utilities.Implementation.Calculator;

namespace UnitTests.Utilities.Calculator
{
    [TestFixture]
    public class PowersRuleResolverTests
    {
        private PowersRuleResolver _powersResolver;

        [SetUp]
        public void Setup()
        {
            _powersResolver = new PowersRuleResolver();
        }

        [Test]
        public void BothPositiveResolution_PerformedCorrectly()
        {
            var input = new List<string>()
            {
                "2",
                "^",
                "2"
            };

            var value = _powersResolver.BothPositiveResolution(input, 1);

            value.Should().BeEquivalentTo("4");
        }

        [Test]
        public void BothNegativeResolution_PerformedCorrectly()
        {
            Assert.That(() => _powersResolver.BothNegativeResolution(null, 2),
                Throws.TypeOf<NotImplementedException>());
        }

        [Test]
        public void FirstTermNegativeResolution_EvenPower_PerformedCorrectly()
        {
            var input = new List<string>()
            {
                "-",
                "2",
                "^",
                "4"
            };

            var value = _powersResolver.FirstTermNegativeResolution(input, 2);

            value.Should().BeEquivalentTo("16");
        }

        [Test]
        public void FirstTermNegativeResolution_OddPower_PerformedCorrectly()
        {
            var input = new List<string>()
            {
                "-",
                "2",
                "^",
                "3"
            };

            var value = _powersResolver.FirstTermNegativeResolution(input, 2);

            value.Should().BeEquivalentTo("-8");
        }

        [Test]
        public void SecondTermNegativeResolution_PerformedCorrectly()
        {
            Assert.That(() => _powersResolver.SecondTermNegativeResolution(null, 2),
                Throws.TypeOf<NotImplementedException>());
        }
    }
}
