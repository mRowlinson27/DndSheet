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
        private IControlStyleApplier _controlStyleApplier;

        public void Setup(bool inEdit)
        {
            _textBoxWrapper = A.Fake<ITextBoxWrapper>();
            _controlStyleApplier = A.Fake<IControlStyleApplier>();
            _editableTextBox = new EditableTextBox(_textBoxWrapper, _controlStyleApplier, _regularStyle, _inEditStyle, inEdit);
        }

        [Test]
        public void EditChangedToFalse_WasTrue_CorrectStyleApplied()
        {
            Setup(true);

            _editableTextBox.Editable = false;

            A.CallTo(() => _controlStyleApplier.Apply(_textBoxWrapper, _regularStyle)).MustHaveHappened();
            A.CallTo(() => _controlStyleApplier.Apply(_textBoxWrapper, _inEditStyle)).MustHaveHappened();
        }

        [Test]
        public void EditChangedToTrue_WasFalse_CorrectStyleApplied()
        {
            Setup(false);

            _editableTextBox.Editable = true;

            A.CallTo(() => _controlStyleApplier.Apply(_textBoxWrapper, _inEditStyle)).MustHaveHappened();
            A.CallTo(() => _controlStyleApplier.Apply(_textBoxWrapper, _regularStyle)).MustHaveHappened();
        }

        [Test]
        public void EditChangedToFalse_WasFalseBefore_NoChange()
        {
            Setup(false);

            _editableTextBox.Editable = false;

            A.CallTo(() => _controlStyleApplier.Apply(_textBoxWrapper, _inEditStyle)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => _controlStyleApplier.Apply(_textBoxWrapper, _regularStyle)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void EditChangedToTrue_WasTrueBefore_NoChange()
        {
            Setup(true);

            _editableTextBox.Editable = true;

            A.CallTo(() => _controlStyleApplier.Apply(_textBoxWrapper, _inEditStyle)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => _controlStyleApplier.Apply(_textBoxWrapper, _regularStyle)).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
