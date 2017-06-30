using System;
using System.Collections.Generic;
using CustomForms.API.DTOs;
using CustomForms.API.Factories;
using CustomForms.API.TableLayoutWrapper;
using CustomFormStructures.API.Decorators;
using CustomFormStructures.Builders;
using DataManipulation.API;
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
        private IPropertyApplier<IControlProperties> _propertyApplier;

        [SetUp]
        public void Setup()
        {
            _tableLayoutDecorators = new List<ITableLayoutDecorator>();
            _layoutDecoratorApplier = A.Fake<ITableLayoutDecoratorApplier>();
            _tableLayoutWrapperFactory = A.Fake<ITableLayoutWrapperFactory>();
            _propertyApplier = A.Fake<IPropertyApplier<IControlProperties>>();
            _centralLayoutBuilder = new CentralLayoutBuilder(_layoutDecoratorApplier, _tableLayoutDecorators, _tableLayoutWrapperFactory, _propertyApplier);
        }

        [Test]
        public void Build_NoStyle_CorrectCallsMade()
        {
            var tableLayout = A.Fake<ITableLayoutWrapper>();
            A.CallTo(() => _tableLayoutWrapperFactory.Create()).Returns(tableLayout);

            _centralLayoutBuilder.Build();

            A.CallTo(() => _propertyApplier.Apply(A<IControlProperties>.Ignored, A<IControlPropertiesStyle>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => _layoutDecoratorApplier.Apply(tableLayout, _tableLayoutDecorators)).MustHaveHappened();
        }

        [Test]
        public void Build_WithStyle_CorrectCallsMade()
        {
            var style = A.Fake<IControlPropertiesStyle>();
            var tableLayout = A.Fake<ITableLayoutWrapper>();
            A.CallTo(() => _tableLayoutWrapperFactory.Create()).Returns(tableLayout);
            A.CallTo(() => _layoutDecoratorApplier.Apply(tableLayout, _tableLayoutDecorators)).Returns(tableLayout);

            _centralLayoutBuilder.Build(style);

            A.CallTo(() => _propertyApplier.Apply(tableLayout, style)).MustHaveHappened();
            A.CallTo(() => _layoutDecoratorApplier.Apply(A<ITableLayoutWrapper>.Ignored, _tableLayoutDecorators)).MustHaveHappened();
        }
    }
}
