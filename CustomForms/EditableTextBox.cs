using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API;
using CustomForms.API.Factories;
using CustomForms.Factories;

namespace CustomForms
{
    class EditableTextBox : IEditableTextBox
    {
        public Control TrueControl { get; set; }
        public event EventHandler Click;
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
            get { return TrueControl.Text; }
            set { TrueControl.Text = value; }
        }

        private ITextBoxWrapper _label;

        public EditableTextBox(ITextBoxWrapper input)
        {
            _label = input;
            TrueControl = _label.TrueControl;

            _label.ReadOnly = true;
            _label.Dock = DockStyle.Fill;
            _label.Anchor = AnchorStyles.Left;
            _label.Cursor = Cursors.Default;
            _label.BorderStyle = BorderStyle.None;
        }

        public void EnterEditMode()
        {
            TrueControl.BackColor = Color.BlueViolet;
        }

        public void LeaveEditMode()
        {
            TrueControl = _label.TrueControl;
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
                control.Width = (int)Math.Ceiling(((float)size.Width) + 10);
            }
        }
    }
}
