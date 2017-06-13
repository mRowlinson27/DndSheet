using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API;
using CustomForms.API.Builders;
using CustomForms.API.DTOs;
using CustomForms.API.Factories;
using CustomForms.DTOs;

namespace CustomForms.Factories
{
    public class EditableTextBoxBuilder : IEditableTextBoxBuilder
    {
        private ITextBoxWrapperFactory _textBoxWrapperFactory;
        private IStyleApplier<ITextBoxWrapper> _styleApplier;
        public EditableTextBoxBuilder(ITextBoxWrapperFactory textBoxWrapperFactory/*, IStyleApplier<ITextBoxWrapper> styleApplier*/)
        {
            _textBoxWrapperFactory = textBoxWrapperFactory;
            //_styleApplier = styleApplier;
        }

        public IEditableTextBox Build(string data, Dictionary<string, object> inEditDict, Dictionary<string, object> notInDict)
        {
            var textBox = _textBoxWrapperFactory.Create();

            textBox.TrueControl.Enter += OnEnter;
            textBox.TrueControl.TextChanged += OnTextChanged;
            textBox.Text = data;

            textBox.BackColor = Color.Transparent;
            textBox.Dock = DockStyle.Fill;
            textBox.Anchor = AnchorStyles.Left;
            textBox.BorderStyle = BorderStyle.None;
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
