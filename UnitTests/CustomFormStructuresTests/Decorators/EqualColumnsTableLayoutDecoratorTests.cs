using System;
using System.Windows.Forms;
using CustomForms.API.TableLayoutWrapper;
using CustomFormStructures.Decorators;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.CustomFormStructuresTests.Decorators
{
    [TestFixture]
    class EqualColumnsTableLayoutDecoratorTests
    {
        private EqualColumnsTableLayoutDecorator _equalColumnsTableLayoutDecorator;
        private ITableLayoutWrapper _tableLayoutWrapper;
        private ITableLayoutColumnStyleCollectionWrapper _layoutColumnStyleCollectionWrapper;

        [SetUp]
        public void Setup()
        {
            _layoutColumnStyleCollectionWrapper = A.Fake<ITableLayoutColumnStyleCollectionWrapper>();
            _tableLayoutWrapper = A.Fake<ITableLayoutWrapper>();
        }

        [Test]
        public void ApplyChanges_WithOneColumn_OneColumnAt100()
        {
            //Arrange
            _equalColumnsTableLayoutDecorator = new EqualColumnsTableLayoutDecorator(1);
            A.CallTo(() => _tableLayoutWrapper.AccessColumnStyles).Returns(_layoutColumnStyleCollectionWrapper);
            A.CallTo(() => _layoutColumnStyleCollectionWrapper.Count).Returns(1);

            //Act
            _equalColumnsTableLayoutDecorator.Apply(_tableLayoutWrapper);

            //Assert
            A.CallTo(() => _layoutColumnStyleCollectionWrapper.Add(
                    A<ColumnStyle>.That.Matches(x => x.SizeType == SizeType.Percent && Math.Abs(x.Width - 100) < 0.1)))
                    .MustHaveHappened();
            A.CallToSet(() => _tableLayoutWrapper.ColumnCount).To(1).MustHaveHappened();
        }

        [Test]
        public void ApplyChanges_WithTwoColumn_TwoColumnAt50()
        {
            //Arrange
            _equalColumnsTableLayoutDecorator = new EqualColumnsTableLayoutDecorator(2);
            A.CallTo(() => _tableLayoutWrapper.AccessColumnStyles).Returns(_layoutColumnStyleCollectionWrapper);
            A.CallTo(() => _layoutColumnStyleCollectionWrapper.Count).Returns(2);

            //Act
            _equalColumnsTableLayoutDecorator.Apply(_tableLayoutWrapper);

            //Assert
            A.CallTo(() => _layoutColumnStyleCollectionWrapper.Add(
                    A<ColumnStyle>.That.Matches(x => x.SizeType == SizeType.Percent && Math.Abs(x.Width - 50) < 0.1)))
                .MustHaveHappened(Repeated.Exactly.Twice);
            A.CallToSet(() => _tableLayoutWrapper.ColumnCount).To(2).MustHaveHappened();
        }

        [Test]
        public void ApplyChanges_With3Column_3ColumnAt33()
        {
            //Arrange
            _equalColumnsTableLayoutDecorator = new EqualColumnsTableLayoutDecorator(3);
            A.CallTo(() => _tableLayoutWrapper.AccessColumnStyles).Returns(_layoutColumnStyleCollectionWrapper);
            A.CallTo(() => _layoutColumnStyleCollectionWrapper.Count).Returns(3);

            //Act
            _equalColumnsTableLayoutDecorator.Apply(_tableLayoutWrapper);

            //Assert
            A.CallTo(() => _layoutColumnStyleCollectionWrapper.Add(
                    A<ColumnStyle>.That.Matches(x => x.SizeType == SizeType.Percent && Math.Abs(x.Width - 33) < 0.1)))
                .MustHaveHappened(Repeated.Exactly.Times(3));
            A.CallToSet(() => _tableLayoutWrapper.ColumnCount).To(3).MustHaveHappened();
        }
    }
}
