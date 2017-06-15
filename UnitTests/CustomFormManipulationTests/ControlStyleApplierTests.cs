using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomFormManipulation;
using CustomFormManipulation.API.DTOs;
using CustomForms.API;
using DataManipulation.API;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.CustomFormManipulationTests
{
    [TestFixture]
    class ControlStyleApplierTests
    {
        private ControlStyleApplier _controlStyleApplier;
        private IPropertyApplier<IControlProperties> _propertyApplier;
        private IEventApplier<IControlEvents> _eventApplier;

        [SetUp]
        public void Setup()
        {
            _propertyApplier = A.Fake<IPropertyApplier<IControlProperties>>();
            _eventApplier = A.Fake<IEventApplier<IControlEvents>>();
            _controlStyleApplier = new ControlStyleApplier(_propertyApplier, _eventApplier);
        }

        [Test]
        public void Apply_PropertiesApplied()
        {
            var original = A.Fake<IControl>();
            var style = A.Fake<IControlStyle>();
            var controlProperties = A.Fake<IControlProperties>();
            A.CallTo(() => style.ControlProperties).Returns(controlProperties);

            _controlStyleApplier.Apply(original, style);

            A.CallTo(() => _propertyApplier.Apply(original, controlProperties)).MustHaveHappened();
        }

        [Test]
        public void Apply_EventsApplied()
        {
            var original = A.Fake<IControl>();
            var style = A.Fake<IControlStyle>();
            var controlEvents = A.Fake<IControlEvents>();
            A.CallTo(() => style.ControlEvents).Returns(controlEvents);

            _controlStyleApplier.Apply(original, style);

            A.CallTo(() => _eventApplier.Apply(original, controlEvents)).MustHaveHappened();
        }

    }
}
