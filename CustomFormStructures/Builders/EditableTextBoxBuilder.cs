﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CustomFormManipulation.API;
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
        private IControlStyleApplier<IControlProperties> _controlStyleApplier;
        public EditableTextBoxBuilder(ITextBoxWrapperFactory textBoxWrapperFactory, IControlStyleApplier<IControlProperties> controlStyleApplier)
        {
            _textBoxWrapperFactory = textBoxWrapperFactory;
            _controlStyleApplier = controlStyleApplier;
        }

        public IEditableTextBox Build(string data, IControlProperties inEditStyle, IControlProperties notInEditStyle)
        {
            var textBox = _textBoxWrapperFactory.Create();

            textBox.TrueControl.Enter += OnEnter;
            textBox.TrueControl.TextChanged += OnTextChanged;
            textBox.Text = data;

            textBox.BackColor = Color.Transparent;
            textBox.Dock = DockStyle.Fill;
            textBox.Anchor = AnchorStyles.Left;
            textBox.BorderStyle = BorderStyle.None;
            return new EditableTextBox(textBox, _controlStyleApplier, inEditStyle, notInEditStyle);
        }

        protected void OnEnter(object sender, System.EventArgs e)
        {
            var control = sender as Control;
            if (control != null) control.Parent.Parent.Focus();
        }

        protected void OnTextChanged(object sender, System.EventArgs e)
        {
            var control = sender as ITextBoxWrapper;
            if (control != null)
            {
                Size size = TextRenderer.MeasureText(control.Text, control.Font);
                control.Width = (int) Math.Ceiling(((float) size.Width) + 10);
            }
        }
    }
}
