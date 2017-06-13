using CustomForms;
using CustomForms.API;
using CustomForms.API.Builders;
using CustomForms.API.Factories;
using CustomForms.Factories;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.CustomFormsTests.Builders
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
            Assert.That(true == false);
        }

    }
}
