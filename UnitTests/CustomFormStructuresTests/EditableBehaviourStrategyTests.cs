using System;
using CustomForms.API.DTOs;
using CustomFormStructures;
using DataManipulation.API;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.CustomFormStructuresTests
{
    [TestFixture]
    class EditableBehaviourStrategyTests
    {
        private EditableBehaviourStrategy _editableBehaviourStrategy;
        private IPropertyApplier<IControlProperties> _propertyApplier;
        private IControlProperties _regularProperties;
        private IControlProperties _inEditProperties;

        [SetUp]
        public void Setup()
        {
            _propertyApplier = A.Fake<IPropertyApplier<IControlProperties>>();
            _editableBehaviourStrategy = new EditableBehaviourStrategy(_propertyApplier, _regularProperties, _inEditProperties);
        }

        [Test]
        public void Apply_RegularPropertiesApplied()
        {
            var original = A.Fake<IControl>();
            _editableBehaviourStrategy.SwapTo(original, true);

            A.CallTo(() => _propertyApplier.Apply(original, _regularProperties)).MustHaveHappened();
        }

        [Test]
        public void Apply_InEditPropertiesApplied()
        {
            var original = A.Fake<IControl>();
            _editableBehaviourStrategy.SwapTo(original, false);

            A.CallTo(() => _propertyApplier.Apply(original, _inEditProperties)).MustHaveHappened();
        }

        [Test]
        public void Apply_DelegateApplied()
        {
            throw new NotImplementedException();
        }

    }
}
