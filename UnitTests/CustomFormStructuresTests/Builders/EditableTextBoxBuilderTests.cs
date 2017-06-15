using System;
using System.Threading;
using CustomFormManipulation.API;
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
        private IControlStyleApplier _controlStyleApplier;

        [SetUp]
        public void Setup()
        {
            _textBoxWrapperFactory = A.Fake<ITextBoxWrapperFactory>();
            _controlStyleApplier = A.Fake<IControlStyleApplier>();
            _editableTextBoxBoxBuilder = new EditableTextBoxBuilder(_textBoxWrapperFactory, _controlStyleApplier);
        }

        [Test]
        public void Build_CorrectCallsMade()
        {
            throw new AbandonedMutexException();
            //_editableTextBoxBoxBuilder.Build()
        }

    }
}
