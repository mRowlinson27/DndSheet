using CustomForms.API;
using CustomForms.API.TableLayoutWrapper;
using CustomForms.Decorators;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.CustomFormsTests.Decorators
{
    [TestFixture]
    public class VerticalScrollTableLayoutDecoratorTests
    {
        private VerticalScrollTableLayoutDecorator _decorator;
        private ITableLayoutWrapper _tableLayoutWrapper;
        private IHScrollPropertiesWrapper _hScrollPropertiesWrapper;
        private IVScrollPropertiesWrapper _vScrollPropertiesWrapper;
        
        [SetUp]
        public void Setup()
        {
            _tableLayoutWrapper = A.Fake<ITableLayoutWrapper>();
            _hScrollPropertiesWrapper = A.Fake<IHScrollPropertiesWrapper>();
            _vScrollPropertiesWrapper = A.Fake<IVScrollPropertiesWrapper>();
            _decorator = new VerticalScrollTableLayoutDecorator();
        }

        [Test]
        public void ApplyChanges_CorrectOrderOfCalls()
        {
            A.CallTo(() => _tableLayoutWrapper.AccessHorizontalScroll).Returns(_hScrollPropertiesWrapper);
            A.CallTo(() => _tableLayoutWrapper.AccessVerticalScroll).Returns(_vScrollPropertiesWrapper);

            _decorator.Apply(_tableLayoutWrapper);

            A.CallToSet(() => _tableLayoutWrapper.AutoScroll).To(false).MustHaveHappened()
                .Then(A.CallToSet(() => _hScrollPropertiesWrapper.Maximum).To(0).MustHaveHappened())
                .Then(A.CallToSet(() => _vScrollPropertiesWrapper.Visible).To(false).MustHaveHappened())
                .Then(A.CallToSet(() => _hScrollPropertiesWrapper.Visible).To(false).MustHaveHappened())
                .Then(A.CallToSet(() => _tableLayoutWrapper.AutoScroll).To(true).MustHaveHappened());

        }
    }
}