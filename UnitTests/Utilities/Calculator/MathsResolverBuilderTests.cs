using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;
using Utilities.Implementation.Calculator;
using Utilities.Interfaces.Calculator;

namespace UnitTests.Utilities.Calculator
{
    [TestFixture]
    public class MathsResolverBuilderTests
    {
        private IMathsResolverFactory _mathsResolverFactory;
        private IMathsRuleResolverFactory _mathsRuleResolverFactory;
        private MathsResolverBuilder _mathsResolverBuilder;

        [SetUp]
        public void Setup()
        {
            _mathsResolverFactory = A.Fake<IMathsResolverFactory>();
            _mathsRuleResolverFactory = A.Fake<IMathsRuleResolverFactory>();
            _mathsResolverBuilder = new MathsResolverBuilder(_mathsResolverFactory, _mathsRuleResolverFactory);
        }

        [Test]
        public void Build_RulesAddedInCorrectOrder()
        {
            _mathsResolverBuilder.Build();

            A.CallTo(() => _mathsRuleResolverFactory.CreatePowersRule()).MustHaveHappened().
                Then(A.CallTo(() => _mathsRuleResolverFactory.CreateMultiplicationRule()).MustHaveHappened()).
                Then(A.CallTo(() => _mathsRuleResolverFactory.CreateDivisionRule()).MustHaveHappened()).
                Then(A.CallTo(() => _mathsRuleResolverFactory.CreateAdditionRule()).MustHaveHappened()).
                Then(A.CallTo(() => _mathsRuleResolverFactory.CreateSubtractionRule()).MustHaveHappened()).
                Then(A.CallTo(() => _mathsResolverFactory.Create(A<List<IMathsRuleResolver>>.Ignored)).MustHaveHappened());
        }
    }
}
