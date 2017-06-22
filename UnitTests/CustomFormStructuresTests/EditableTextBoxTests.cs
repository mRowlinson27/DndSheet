using System;
using CustomFormManipulation.API;
using CustomFormManipulation.API.DTOs;
using CustomForms.API;
using CustomForms.API.DTOs;
using CustomFormStructures;
using CustomFormStructures.API;
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

        public void Setup(EditableStatus status)
        {
            _textBoxWrapper = A.Fake<ITextBoxWrapper>();
            _swappableStrategy = A.Fake<ISwappableStrategy>();
            _editableTextBox = new EditableTextBox(_textBoxWrapper, _swappableStrategy, status);
        }

        [Test]
        public void InRegularMode_ChangedToEdit_CorrectStyleApplied()
        {
            Setup(EditableStatus.Regular);

            _editableTextBox.EditableStatus = EditableStatus.InEdit;

            A.CallTo(() => _swappableStrategy.SwapTo(_textBoxWrapper, true)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => _swappableStrategy.SwapTo(_textBoxWrapper, false)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void InEdit_ChangedToRegularMode_CorrectStyleApplied()
        {
            Setup(EditableStatus.InEdit);

            _editableTextBox.EditableStatus = EditableStatus.Regular;

            A.CallTo(() => _swappableStrategy.SwapTo(_textBoxWrapper, true)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => _swappableStrategy.SwapTo(_textBoxWrapper, false)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void InEdit_ChangedToEdit_NoChange()
        {
            Setup(EditableStatus.InEdit);

            _editableTextBox.EditableStatus = EditableStatus.InEdit;

            A.CallTo(() => _swappableStrategy.SwapTo(_textBoxWrapper, true)).MustNotHaveHappened();
            A.CallTo(() => _swappableStrategy.SwapTo(_textBoxWrapper, false)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void InRegularMode_ChangedToRegularMode_NoChange()
        {
            Setup(EditableStatus.Regular);

            _editableTextBox.EditableStatus = EditableStatus.Regular;

            A.CallTo(() => _swappableStrategy.SwapTo(_textBoxWrapper, true)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => _swappableStrategy.SwapTo(_textBoxWrapper, false)).MustNotHaveHappened();
        }
    }
}
