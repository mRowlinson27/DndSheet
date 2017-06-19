using System;
using CustomFormManipulation.API;
using CustomFormManipulation.API.DTOs;
using CustomForms.API;
using CustomFormStructures;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.CustomFormStructuresTests
{
    [TestFixture]
    class EditableTextBoxTests
    {
        private EditableTextBox _editableTextBox;
        private ITextBoxWrapper _textBoxWrapper;
        private IControlStyle _regularStyle;
        private IControlStyle _inEditStyle;
        private ISwappableStrategy _swappableStrategy;

        public void Setup(bool inEdit)
        {
            _textBoxWrapper = A.Fake<ITextBoxWrapper>();
            _swappableStrategy = A.Fake<ISwappableStrategy>();
            _editableTextBox = new EditableTextBox(_textBoxWrapper, _swappableStrategy, inEdit);
        }

        [Test]
        public void EditChangedToFalse_WasTrue_CorrectStyleApplied()
        {
            Setup(true);

            _editableTextBox.Editable = false;

            Assert.That(false);
        }

        [Test]
        public void EditChangedToTrue_WasFalse_CorrectStyleApplied()
        {
            Setup(false);

            _editableTextBox.Editable = true;

            Assert.That(false);
        }

        [Test]
        public void EditChangedToFalse_WasFalseBefore_NoChange()
        {
            Setup(false);

            _editableTextBox.Editable = false;

            Assert.That(false);
        }

        [Test]
        public void EditChangedToTrue_WasTrueBefore_NoChange()
        {
            Setup(true);

            _editableTextBox.Editable = true;

            Assert.That(false);
        }
    }
}
