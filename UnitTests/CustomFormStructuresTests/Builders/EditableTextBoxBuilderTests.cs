using System;
using System.Threading;
using CustomForms.API;
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
        private IStyleApplier<IControlProperties> _styleApplier;

        [SetUp]
        public void Setup()
        {
            _textBoxWrapperFactory = A.Fake<ITextBoxWrapperFactory>();
            _styleApplier = A.Fake<IStyleApplier<IControlProperties>>();
            _editableTextBoxBoxBuilder = new EditableTextBoxBuilder(_textBoxWrapperFactory, _styleApplier);
        }

        [Test]
        public void Build_CorrectCallsMade()
        {
            throw new AbandonedMutexException();
            //_editableTextBoxBoxBuilder.Build()
        }

    }
}
