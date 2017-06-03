using System.Windows.Forms;
using CustomForms;
using CustomForms.API;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.CustomFormsTests
{
    [TestFixture]
    public class VerticalScrollTableLayoutDecoratorTests
    {
        private VerticalScrollTableLayoutDecorator _decorator;
        private ITableLayoutWrapper _tableLayoutWrapper;
        
        [SetUp]
        public void Setup()
        {
            _tableLayoutWrapper = A.Fake<ITableLayoutWrapper>();
            _decorator = new VerticalScrollTableLayoutDecorator();
        }

        [Test]
        public void ApplyChanges_CorrectOrderOfCalls()
        {
            A.CallTo(() => _tableLayoutWrapper.HorizontalScroll).Returns(null);

            _decorator.Apply(_tableLayoutWrapper);

            A.CallToSet(() => _tableLayoutWrapper.AutoScroll).To(false).MustHaveHappened()
                .Then(A.CallToSet(() => _tableLayoutWrapper.HorizontalScroll.Maximum).To(0).MustHaveHappened())
                .Then(A.CallToSet(() => _tableLayoutWrapper.VerticalScroll.Visible).To(false).MustHaveHappened())
                .Then(A.CallToSet(() => _tableLayoutWrapper.HorizontalScroll.Visible).To(false).MustHaveHappened())
                .Then(A.CallToSet(() => _tableLayoutWrapper.AutoScroll).To(true).MustHaveHappened());

        }
    }
}