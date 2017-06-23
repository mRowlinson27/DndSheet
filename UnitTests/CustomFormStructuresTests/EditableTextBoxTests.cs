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
        private ISwappableTextboxStrategy _swappableTextboxStrategy;

        public void Setup(EditableStatus status)
        {
            _textBoxWrapper = A.Fake<ITextBoxWrapper>();
            _swappableTextboxStrategy = A.Fake<ISwappableTextboxStrategy>();
            _editableTextBox = new EditableTextBox(_textBoxWrapper, _swappableTextboxStrategy, status);
        }

        [Test]
        public void InRegularMode_ChangedToEdit_CorrectStyleApplied()
        {
            Setup(EditableStatus.Regular);

            _editableTextBox.EditableStatus = EditableStatus.InEdit;

            A.CallTo(() => _swappableTextboxStrategy.SwapTo(_textBoxWrapper, true)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => _swappableTextboxStrategy.SwapTo(_textBoxWrapper, false)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void InEdit_ChangedToRegularMode_CorrectStyleApplied()
        {
            Setup(EditableStatus.InEdit);

            _editableTextBox.EditableStatus = EditableStatus.Regular;

            A.CallTo(() => _swappableTextboxStrategy.SwapTo(_textBoxWrapper, true)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => _swappableTextboxStrategy.SwapTo(_textBoxWrapper, false)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void InEdit_ChangedToEdit_NoChange()
        {
            Setup(EditableStatus.InEdit);

            _editableTextBox.EditableStatus = EditableStatus.InEdit;

            A.CallTo(() => _swappableTextboxStrategy.SwapTo(_textBoxWrapper, true)).MustNotHaveHappened();
            A.CallTo(() => _swappableTextboxStrategy.SwapTo(_textBoxWrapper, false)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void InRegularMode_ChangedToRegularMode_NoChange()
        {
            Setup(EditableStatus.Regular);

            _editableTextBox.EditableStatus = EditableStatus.Regular;

            A.CallTo(() => _swappableTextboxStrategy.SwapTo(_textBoxWrapper, true)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => _swappableTextboxStrategy.SwapTo(_textBoxWrapper, false)).MustNotHaveHappened();
        }
    }
}
