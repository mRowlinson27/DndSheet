using CustomForms;
using CustomForms.API;
using CustomForms.API.TableLayoutWrapper;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.CustomFormsTests
{
    [TestFixture]
    public class VerticalScrollStrategyTests
    {
        private IWin32Adapter _win32Adapter;
        private VerticalScrollStrategy _strategy;
        private ITableLayoutWrapper _tableLayoutWrapper;
        private IHScrollPropertiesWrapper _hScrollPropertiesWrapper;
        private IVScrollPropertiesWrapper _vScrollPropertiesWrapper;
        
        [SetUp]
        public void Setup()
        {
            _tableLayoutWrapper = A.Fake<ITableLayoutWrapper>();
            _hScrollPropertiesWrapper = A.Fake<IHScrollPropertiesWrapper>();
            _vScrollPropertiesWrapper = A.Fake<IVScrollPropertiesWrapper>();
            _win32Adapter = A.Fake<IWin32Adapter>();
            _strategy = new VerticalScrollStrategy(_win32Adapter);
        }

        [Test]
        public void ExecuteOn_CorrectOrderOfCalls()
        {
            A.CallTo(() => _tableLayoutWrapper.AccessHorizontalScroll).Returns(_hScrollPropertiesWrapper);
            A.CallTo(() => _tableLayoutWrapper.AccessVerticalScroll).Returns(_vScrollPropertiesWrapper);

            _strategy.ExecuteOn(_tableLayoutWrapper);

            A.CallToSet(() => _tableLayoutWrapper.AutoScroll).To(false).MustHaveHappened()
                .Then(A.CallToSet(() => _hScrollPropertiesWrapper.Maximum).To(0).MustHaveHappened())
                .Then(A.CallToSet(() => _vScrollPropertiesWrapper.Visible).To(false).MustHaveHappened())
                .Then(A.CallToSet(() => _hScrollPropertiesWrapper.Visible).To(false).MustHaveHappened())
                .Then(A.CallToSet(() => _tableLayoutWrapper.AutoScroll).To(true).MustHaveHappened());

        }

        [Test]
        public void ExecuteOn_CanOnlyBeOnOne()
        {
            A.CallTo(() => _tableLayoutWrapper.AccessHorizontalScroll).Returns(_hScrollPropertiesWrapper);
            A.CallTo(() => _tableLayoutWrapper.AccessVerticalScroll).Returns(_vScrollPropertiesWrapper);

            _strategy.ExecuteOn(_tableLayoutWrapper);
            _strategy.ExecuteOn(_tableLayoutWrapper);

            A.CallToSet(() => _tableLayoutWrapper.AutoScroll).To(false).MustHaveHappened()
                .Then(A.CallToSet(() => _hScrollPropertiesWrapper.Maximum).To(0).MustHaveHappened(Repeated.Exactly.Once))
                .Then(A.CallToSet(() => _vScrollPropertiesWrapper.Visible).To(false).MustHaveHappened(Repeated.Exactly.Once))
                .Then(A.CallToSet(() => _hScrollPropertiesWrapper.Visible).To(false).MustHaveHappened(Repeated.Exactly.Once))
                .Then(A.CallToSet(() => _tableLayoutWrapper.AutoScroll).To(true).MustHaveHappened(Repeated.Exactly.Once));
        }
    }
}