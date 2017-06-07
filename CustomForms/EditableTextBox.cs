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
        public bool Editable { get; set; }
        public string Text
        {
            get { return _control.Text; }
            set { _control.Text = value; }
        }

        private ILabelWrapper _control;

        public EditableTextBox(ILabelWrapper input)
        {
            _control = input;
            TrueControl = _control.TrueControl;
        }
    }
}
