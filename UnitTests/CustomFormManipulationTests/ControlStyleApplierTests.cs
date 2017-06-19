using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomFormManipulation;
using CustomFormManipulation.API.DTOs;
using CustomForms.API;
using CustomForms.API.DTOs;
using CustomForms.TableLayoutWrapperFields;
using DataManipulation.API;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.CustomFormManipulationTests
{
    [TestFixture]
    class ControlStyleApplierTests
    {
        private EditableBehaviourStrategy _editableBehaviourStrategy;
        private IPropertyApplier<IControlProperties> _propertyApplier;

        [SetUp]
        public void Setup()
        {
            _propertyApplier = A.Fake<IPropertyApplier<IControlProperties>>();
            _editableBehaviourStrategy = new EditableBehaviourStrategy(_propertyApplier, null, null);
        }

        [Test]
        public void Apply_PropertiesApplied()
        {
            var original = A.Fake<IControl>();
            _editableBehaviourStrategy.SwapTo(original, true);

            A.CallTo(() => _propertyApplier.Apply(original, new TableLayoutWrapper())).MustHaveHappened();
        }

        [Test]
        public void Apply_EventsApplied()
        {
            var original = A.Fake<IControl>();
            _editableBehaviourStrategy.SwapTo(original, false);

            A.CallTo(() => _propertyApplier.Apply(original, new TableLayoutWrapper())).MustHaveHappened();
        }

    }
}
