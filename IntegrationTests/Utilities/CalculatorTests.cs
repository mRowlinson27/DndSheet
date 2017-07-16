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

namespace IntegrationTests.Utilities
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
            _mathsResolver = new MathsResolver(new EquationPartsIdentifier());
            _nestingIdentifier = new NestingIdentifier();
            _calculator = new Calculator(_mathsResolver, _nestingIdentifier);
        }

        [Test]
        public void Calculate_SimpleEquation1()
        {
            var equation = "(17+10)/2";

            var answer = _calculator.Calculate(equation);

            answer.Should().Be(13);
        }

        [Test]
        public void Calculate_SimpleEquation2()
        {
            var equation = "(17-10)/2";

            var answer = _calculator.Calculate(equation);

            answer.Should().Be(3);
        }

        [Test]
        public void Calculate_SimpleEquation3()
        {
            var equation = "(17-20)/2";

            var answer = _calculator.Calculate(equation);

            answer.Should().Be(-1);
        }

        [Test]
        public void Calculate_SimpleEquation4()
        {
            var equation = "10 * 5 - (4 + 2) ^ 2 + 6 / 3";

            var answer = _calculator.Calculate(equation);

            answer.Should().Be(16);
        }
    }
}
