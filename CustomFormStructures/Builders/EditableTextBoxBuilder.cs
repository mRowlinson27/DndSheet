using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CustomFormManipulation.API;
using CustomFormManipulation.API.DTOs;
using CustomForms;
using CustomForms.API;
using CustomForms.API.DTOs;
using CustomForms.API.Factories;
using CustomFormStructures.API;
using CustomFormStructures.API.Builders;
using CustomFormStructures.API.Factories;
using DataManipulation.API;

namespace CustomFormStructures.Builders
{
    public class EditableTextBoxBuilder : IEditableTextBoxBuilder
    {
        private readonly ISwappableStrategyFactory _swappableStrategyFactory;
        private readonly IEditableTextBoxFactory _editableTextBoxFactory;
        private ITextBoxWrapperFactory _textBoxWrapperFactory;
        public EditableTextBoxBuilder(ITextBoxWrapperFactory textBoxWrapperFactory, ISwappableStrategyFactory swappableStrategyFactory, IEditableTextBoxFactory editableTextBoxFactory)
        {
            _swappableStrategyFactory = swappableStrategyFactory;
            _editableTextBoxFactory = editableTextBoxFactory;
            _textBoxWrapperFactory = textBoxWrapperFactory;
        }

        public IEditableTextBox Build(string data, ITextboxProperties regularStyle, ITextboxProperties inEditStyle)
        {
            var textBox = _textBoxWrapperFactory.Create();
            var swappableStrategy = _swappableStrategyFactory.Create(regularStyle, inEditStyle);
            textBox.Text = data;
            textBox.Dock = DockStyle.Fill;
            textBox.Anchor = AnchorStyles.Left;
            textBox.BorderStyle = BorderStyle.None;
            var result = _editableTextBoxFactory.Create(textBox, swappableStrategy, EditableStatus.Regular);
            return result;
        }
    }
}
