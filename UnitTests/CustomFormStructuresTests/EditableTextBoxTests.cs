using System;
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

        [SetUp]
        public void Setup()
        {
            _textBoxWrapper = A.Fake<ITextBoxWrapper>();
            _editableTextBox = new EditableTextBox(_textBoxWrapper);
        }

        [Test]
        public void EditChangedToFalse_WasTrue_CorrectStyleApplied()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void EditChangedToTrue_WasFalse_CorrectStyleApplied()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void EditChangedToFalse_WasFalseBefore_NoChange()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void EditChangedToTrue_WasTrueBefore_NoChange()
        {
            throw new NotImplementedException();
        }
    }
}
