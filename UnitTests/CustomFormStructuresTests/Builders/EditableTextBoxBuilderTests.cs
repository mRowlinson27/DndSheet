using System;
using CustomForms.API.Factories;
using CustomFormStructures.API.Builders;
using CustomFormStructures.Builders;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.CustomFormStructuresTests.Builders
{
    [TestFixture]
    class EditableTextBoxBuilderTests
    {

        private IEditableTextBoxBuilder _editableTextBoxBoxBuilder;
        private ITextBoxWrapperFactory _textBoxWrapperFactory;

        [SetUp]
        public void Setup()
        {
            _textBoxWrapperFactory = A.Fake<ITextBoxWrapperFactory>();
            _editableTextBoxBoxBuilder = new EditableTextBoxBuilder(_textBoxWrapperFactory);
        }

        [Test]
        public void Build_CorrectCallsMade()
        {
            throw new NotImplementedException();
        }

    }
}
