using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CustomFormManipulation.API;
using CustomFormManipulation.API.DTOs;
using CustomForms;
using CustomForms.API;
using CustomForms.API.Factories;
using CustomFormStructures.API;
using CustomFormStructures.API.Builders;

namespace CustomFormStructures.Builders
{
    public class EditableTextBoxBuilder : IEditableTextBoxBuilder
    {
        private ITextBoxWrapperFactory _textBoxWrapperFactory;
        private IControlStyleApplier _controlStyleApplier;
        public EditableTextBoxBuilder(ITextBoxWrapperFactory textBoxWrapperFactory, IControlStyleApplier controlStyleApplier)
        {
            _textBoxWrapperFactory = textBoxWrapperFactory;
            _controlStyleApplier = controlStyleApplier;
        }

        public IEditableTextBox Build(string data, IControlStyle regularStyle, IControlStyle inEditStyle)
        {
            var textBox = _textBoxWrapperFactory.Create();

            
            textBox.Text = data;
            textBox.Dock = DockStyle.Fill;
            textBox.Anchor = AnchorStyles.Left;
            textBox.BorderStyle = BorderStyle.None;
            var result = new EditableTextBox(textBox, _controlStyleApplier, regularStyle, inEditStyle);
            return result;
        }
    }
}
