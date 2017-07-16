using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Utilities.Implementation.Calculator;

namespace UnitTests.Utilities
{
    [TestFixture]
    public class NestingIdentifierTests
    {
        private NestingIdentifier _nestingIdentifier;

        [SetUp]
        public void Setup()
        {
            _nestingIdentifier = new NestingIdentifier();
        }

        [Test]
        public void FindDeepestNest_FindsSingleLayerBrackets()
        {
            const string equation = "{1}";

            var response = _nestingIdentifier.FindDeepestNest(equation);

            response.StartIndex.Should().Be(0);
            response.Length.Should().Be(3);
        }

        [Test]
        public void FindDeepestNest_FindsDoubleLayerBrackets()
        {
            const string equation = "{{hi there}}";

            var response = _nestingIdentifier.FindDeepestNest(equation);

            response.StartIndex.Should().Be(1);
            response.Length.Should().Be(10);
        }

        [Test]
        public void FindDeepestNest_FindsFirstOfTwoSingleLayerBrackets()
        {
            const string equation = "{test}{test2}";

            var response = _nestingIdentifier.FindDeepestNest(equation);

            response.StartIndex.Should().Be(0);
            response.Length.Should().Be(6);
        }

        [Test]
        public void FindDeepestNest_FindsFirstOfTwoTripleLayerBrackets()
        {
            const string equation = "{[test2{hi}{ho}]test2}";

            var response = _nestingIdentifier.FindDeepestNest(equation);

            response.StartIndex.Should().Be(7);
            response.Length.Should().Be(4);
        }

        [Test]
        public void FindDeepestNest_NoBrackets_ReturnsNull()
        {
            const string equation = "abcdefg";

            var response = _nestingIdentifier.FindDeepestNest(equation);

            response.Should().BeNull();
        }

        [Test]
        public void FindDeepestNest_NullString_ReturnsNull()
        {
            const string equation = null;

            Assert.That(() => _nestingIdentifier.FindDeepestNest(equation),
                Throws.TypeOf<ArgumentNullException>());
        }
    }
}
