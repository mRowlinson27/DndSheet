using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API;
using CustomForms.API.Factories;
using CustomForms.Factories;

namespace CustomForms
{
    class EditableTextBox : IEditableTextBox, ILabelWrapper
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
                    EnterEditMode();
                }
                else if (!_inEdit && value)
                {
                    LeaveEditMode();
                }
                _inEdit = value;
            }
        }
        public string Text
        {
            get { return TrueControl.Text; }
            set { TrueControl.Text = value; }
        }

        private ILabelWrapper _label;

        public EditableTextBox(ILabelWrapper input)
        {
            _label = input;
            TrueControl = _label.TrueControl;
            var test = new TextBox();
        }

        public void EnterEditMode()
        {
            TrueControl = null;
            _label.TrueControl.Visible = false;
        }

        public void LeaveEditMode()
        {
            TrueControl = _label.TrueControl;
        }
    }
}
