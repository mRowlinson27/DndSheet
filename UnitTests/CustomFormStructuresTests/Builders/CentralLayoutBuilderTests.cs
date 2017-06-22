using System;
using System.Collections.Generic;
using CustomForms.API.Factories;
using CustomForms.API.TableLayoutWrapper;
using CustomFormStructures.API.Decorators;
using CustomFormStructures.Builders;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.CustomFormStructuresTests.Builders
{
    [TestFixture]
    class CentralLayoutBuilderTests
    {
        private CentralLayoutBuilder _centralLayoutBuilder;
        private ITableLayoutDecoratorApplier _layoutDecoratorApplier;
        private ITableLayoutWrapperFactory _tableLayoutWrapperFactory;
        private List<ITableLayoutDecorator> _tableLayoutDecorators;

        [SetUp]
        public void Setup()
        {
            _tableLayoutDecorators = new List<ITableLayoutDecorator>();
            _layoutDecoratorApplier = A.Fake<ITableLayoutDecoratorApplier>();
            _tableLayoutWrapperFactory = A.Fake<ITableLayoutWrapperFactory>();
            _centralLayoutBuilder = new CentralLayoutBuilder(_layoutDecoratorApplier, _tableLayoutDecorators, _tableLayoutWrapperFactory);
        }

        [Test]
        public void Build_CorrectCallsMade()
        {
            A.CallTo(() => _tableLayoutWrapperFactory.Create()).Returns(A.Fake<ITableLayoutWrapper>());
            _centralLayoutBuilder.Build();

            A.CallTo(() => _layoutDecoratorApplier.Apply(A<ITableLayoutWrapper>.Ignored, _tableLayoutDecorators)).MustHaveHappened();
        }

        [Test]
        public void Build_StyleInvoked()
        {
            throw new NotImplementedException();
        }
    }
}
