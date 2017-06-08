using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API;
using CustomForms.API.Factories;

namespace CustomForms.Factories
{
    public class EditableTextBoxBuilder : IEditableTextBoxBuilder
    {
        private ITextBoxWrapperFactory _textBoxWrapperFactory;
        public EditableTextBoxBuilder(ITextBoxWrapperFactory textBoxWrapperFactory)
        {
            _textBoxWrapperFactory = textBoxWrapperFactory;
        }

        public IEditableTextBox Build(string data)
        {
            var textBox = _textBoxWrapperFactory.Create();

            textBox.BackColor = Color.Transparent;

            textBox.TrueControl.Enter += OnEnter;
            textBox.TrueControl.TextChanged += OnTextChanged;
            textBox.Text = data;
            return new EditableTextBox(textBox);
        }

        protected void OnEnter(object sender, System.EventArgs e)
        {
            var control = sender as Control;
            if (control != null) control.Parent.Parent.Focus();
        }

        protected void OnTextChanged(object sender, System.EventArgs e)
        {
            var control = sender as TextBoxWrapper;
            if (control != null)
            {
                Size size = TextRenderer.MeasureText(control.Text, control.Font);
                control.Width = (int) Math.Ceiling(((float) size.Width) + 10);
            }
        }
    }
}
