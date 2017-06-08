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

        private IControl _label;

        public EditableTextBox(IControl input)
        {
            _label = input;
            TrueControl = _label.TrueControl;
        }

        public void EnterEditMode()
        {
            TrueControl.BackColor = Color.BlueViolet;
        }

        public void LeaveEditMode()
        {
            TrueControl = _label.TrueControl;
        }
    }
}
