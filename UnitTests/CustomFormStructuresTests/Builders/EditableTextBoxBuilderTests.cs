using System;
using System.Threading;
using System.Windows.Forms;
using CustomFormManipulation.API;
using CustomForms.API;
using CustomForms.API.DTOs;
using CustomForms.API.Factories;
using CustomFormStructures.API;
using CustomFormStructures.API.Builders;
using CustomFormStructures.API.Factories;
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
        private ISwappableStrategyFactory _swappableStrategyFactory;
        private IEditableTextBoxFactory _editableTextBoxFactory;

        [SetUp]
        public void Setup()
        {
            _textBoxWrapperFactory = A.Fake<ITextBoxWrapperFactory>();
            _swappableStrategyFactory = A.Fake<ISwappableStrategyFactory>();
            _editableTextBoxFactory = A.Fake<IEditableTextBoxFactory>();
            _editableTextBoxBoxBuilder = new EditableTextBoxBuilder(_textBoxWrapperFactory, _swappableStrategyFactory, _editableTextBoxFactory);
        }

        [Test]
        public void Build_CorrectCallsMade()
        {
            const string data = "test";
            var regularStyle = A.Fake<ITextboxProperties>();
            var inEditStyle = A.Fake<ITextboxProperties>();
            var swappableStrategy = A.Fake<ISwappableTextboxStrategy>();
            var textBox = A.Fake<ITextBoxWrapper>();
            A.CallTo(() => _swappableStrategyFactory.Create(regularStyle, inEditStyle)).Returns(swappableStrategy);
            A.CallTo(() => _textBoxWrapperFactory.Create()).Returns(textBox);

            _editableTextBoxBoxBuilder.Build(data, regularStyle, inEditStyle);

            A.CallToSet(() => textBox.Text).To(data).MustHaveHappened();
            A.CallToSet(() => textBox.Dock).To(DockStyle.Fill).MustHaveHappened();
            A.CallToSet(() => textBox.Anchor).To(AnchorStyles.Left).MustHaveHappened();
            A.CallToSet(() => textBox.BorderStyle).To(BorderStyle.None).MustHaveHappened();
            A.CallTo(() => _editableTextBoxFactory.Create(textBox, swappableStrategy, EditableStatus.Regular))
                .MustHaveHappened();
        }

    }
}
