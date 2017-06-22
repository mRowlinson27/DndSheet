using System.Collections.Generic;
using CustomForms.API.TableLayoutWrapper;
using CustomFormStructures.API.Decorators;
using CustomFormStructures.Decorators;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.CustomFormStructuresTests.Decorators
{
    [TestFixture]
    class TableLayoutDecoratorApplierTests
    {
        private TableLayoutDecoratorApplier _tableLayoutDecoratorApplier;
        private ITableLayoutWrapper _tableLayoutWrapper;
        private ITableLayoutDecorator _tableLayoutDecorator1;
        private ITableLayoutDecorator _tableLayoutDecorator2;
        private List<ITableLayoutDecorator> _tableLayoutDecorators;

        [SetUp]
        public void Setup()
        {
            _tableLayoutWrapper = A.Fake<ITableLayoutWrapper>();

            _tableLayoutDecorator1 = A.Fake<ITableLayoutDecorator>();
            _tableLayoutDecorator2 = A.Fake<ITableLayoutDecorator>();
            _tableLayoutDecorators = new List<ITableLayoutDecorator>()
            {
                _tableLayoutDecorator1, _tableLayoutDecorator2
            };
            _tableLayoutDecoratorApplier = new TableLayoutDecoratorApplier();
        }

        [Test]
        public void Apply_AppliesAllDecoraters()
        {
            A.CallTo(() => _tableLayoutDecorator1.Apply(_tableLayoutWrapper)).Returns(_tableLayoutWrapper);

            _tableLayoutDecoratorApplier.Apply(_tableLayoutWrapper, _tableLayoutDecorators);

            A.CallTo(() => _tableLayoutDecorator1.Apply(_tableLayoutWrapper)).MustHaveHappened();
            A.CallTo(() => _tableLayoutDecorator2.Apply(_tableLayoutWrapper)).MustHaveHappened();
        }
    }
}
