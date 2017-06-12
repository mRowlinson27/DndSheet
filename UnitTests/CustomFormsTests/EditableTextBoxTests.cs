using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms;
using CustomForms.API;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.CustomFormsTests
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
