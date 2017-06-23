using System;
using CustomForms.API;
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
        private EditableBehaviourTextboxStrategy _editableBehaviourTextboxStrategy;
        private IPropertyApplier<ITextboxProperties> _propertyApplier;
        private ITextboxProperties _regularProperties;
        private ITextboxProperties _inEditProperties;

        [SetUp]
        public void Setup()
        {
            _propertyApplier = A.Fake<IPropertyApplier<ITextboxProperties>>();
            _editableBehaviourTextboxStrategy = new EditableBehaviourTextboxStrategy(_propertyApplier, _regularProperties, _inEditProperties);
        }

        [Test]
        public void Apply_RegularPropertiesApplied()
        {
            var original = A.Fake<ITextBoxWrapper>();
            _editableBehaviourTextboxStrategy.SwapTo(original, true);

            A.CallTo(() => _propertyApplier.Apply(original, _regularProperties)).MustHaveHappened();
        }

        [Test]
        public void Apply_InEditPropertiesApplied()
        {
            var original = A.Fake<ITextBoxWrapper>();
            _editableBehaviourTextboxStrategy.SwapTo(original, false);

            A.CallTo(() => _propertyApplier.Apply(original, _inEditProperties)).MustHaveHappened();
        }

        [Test]
        public void Apply_DelegateApplied()
        {
            var original = A.Fake<ITextBoxWrapper>();
            _editableBehaviourTextboxStrategy.SwapTo(original, false);

            original.Enter += Raise.WithEmpty();

            throw new Exception("NEED PARENTS IN MY CONTROLS");
        }

    }
}
