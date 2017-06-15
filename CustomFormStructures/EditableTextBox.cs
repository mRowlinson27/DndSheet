using System;
using System.Drawing;
using System.Windows.Forms;
using CustomFormManipulation.API;
using CustomForms.API;
using CustomFormStructures.API;

namespace CustomFormStructures
{
    public class EditableTextBox : IEditableTextBox
    {
        public Control TrueControl { get; set; }
        private bool _inEdit = false;
        public bool Editable
        {
            get { return _inEdit; }
            set
            {
                if (_inEdit && !value)
                {
                    LeaveEditMode();
                }
                else if (!_inEdit && value)
                {
                    EnterEditMode();
                }
                _inEdit = value;
            }
        }
        public string Text
        {
            get { return _textBox.Text; }
            set { _textBox.Text = value; }
        }

        private ITextBoxWrapper _textBox;
        private IControlStyleApplier<IControlProperties> _controlStyleApplier;
        private IControlProperties _inEditStyle;
        private IControlProperties _notInEditStyle;

        public EditableTextBox(ITextBoxWrapper input, IControlStyleApplier<IControlProperties> controlStyleApplier, IControlProperties inEditStyle, IControlProperties notInEditStyle)
        {
            _textBox = input;
            TrueControl = _textBox.TrueControl;
            _controlStyleApplier = controlStyleApplier;
            _inEditStyle = inEditStyle;
            _notInEditStyle = notInEditStyle;
            LeaveEditMode();
        }

        private void EnterEditMode()
        {
            _textBox.Enabled = true;
            _textBox.ReadOnly = false;
            _textBox.Cursor = Cursors.IBeam;
            _controlStyleApplier.Apply(_textBox, _inEditStyle);
        }

        private void LeaveEditMode()
        {
            _textBox.Enabled = false;
            _textBox.ReadOnly = true;
            _textBox.Cursor = Cursors.Default;
            _controlStyleApplier.Apply(_textBox, _notInEditStyle);
        }

        protected void OnEnter(object sender, System.EventArgs e)
        {
            var control = sender as Control;
            if (control != null)
            {
                control.Parent.Parent.Focus();
            }
        }

        protected void OnTextChanged(object sender, System.EventArgs e)
        {
            var control = sender as ITextBoxWrapper;
            if (control != null)
            {
                Size size = TextRenderer.MeasureText(control.Text, control.Font);
                control.Width = (int)Math.Ceiling(((float)size.Width) + 10);
            }
        }
    }
}
