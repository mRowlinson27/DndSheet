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
        private IPropertyApplier<ITextBoxProperties> _propertyApplier;
        private ITextBoxPropertiesStyle _regularProperties;
        private ITextBoxPropertiesStyle _inEditProperties;

        [SetUp]
        public void Setup()
        {
            _propertyApplier = A.Fake<IPropertyApplier<ITextBoxProperties>>();
            _editableBehaviourTextboxStrategy = new EditableBehaviourTextboxStrategy(_propertyApplier, _regularProperties, _inEditProperties);
        }

        [Test]
        public void SwapTo_RegularPropertiesApplied()
        {
            var original = A.Fake<ITextBoxWrapper>();
            _editableBehaviourTextboxStrategy.SwapTo(original, true);

            A.CallTo(() => _propertyApplier.Apply(original, _regularProperties)).MustHaveHappened();
        }

        [Test]
        public void SwapTo_InEditPropertiesApplied()
        {
            var original = A.Fake<ITextBoxWrapper>();
            _editableBehaviourTextboxStrategy.SwapTo(original, false);

            A.CallTo(() => _propertyApplier.Apply(original, _inEditProperties)).MustHaveHappened();
        }

        [Test]
        public void SwapTo_EditModeTextChanged_FunctionCalled()
        {
            var original = A.Fake<ITextBoxWrapper>();
            _editableBehaviourTextboxStrategy.SwapTo(original, false);

            original.TextChanged += Raise.WithEmpty();

            A.CallToSet(() => original.Width).MustHaveHappened();
        }

        [Test]
        public void SwapTo_ChangedFromInEditMode_TextChangedFunctionNotCalled()
        {
            var original = A.Fake<ITextBoxWrapper>();
            _editableBehaviourTextboxStrategy.SwapTo(original, false);
            _editableBehaviourTextboxStrategy.SwapTo(original, true);

            original.TextChanged += Raise.WithEmpty();

            A.CallToSet(() => original.Width).MustNotHaveHappened();
        }

    }
}
