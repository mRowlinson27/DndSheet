using System;
using System.Drawing;
using System.Windows.Forms;
using CustomFormManipulation.API;
using CustomFormManipulation.API.DTOs;
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
                    EnterRegularMode();
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
        private IControlStyleApplier _controlStyleApplier;
        private IControlStyle _inEditStyle;
        private IControlStyle _regularStyle;

        public EditableTextBox(ITextBoxWrapper input, IControlStyleApplier controlStyleApplier, IControlStyle regularStyle, IControlStyle inEditStyle, bool inEdit = false)
        {
            _textBox = input;
            TrueControl = _textBox.TrueControl;
            _controlStyleApplier = controlStyleApplier;
            _inEditStyle = inEditStyle;
            _regularStyle = regularStyle;
            _inEdit = inEdit;
            if (!_inEdit)
            {
                EnterRegularMode();
            }
            else
            {
                EnterEditMode();
            }
        }

        private void EnterEditMode()
        {
            _textBox.Enabled = true;
            _textBox.ReadOnly = false;
            _textBox.Cursor = Cursors.IBeam;
            _controlStyleApplier.Apply(_textBox, _inEditStyle);
        }

        private void EnterRegularMode()
        {
            _textBox.Enabled = false;
            _textBox.ReadOnly = true;
            _textBox.Cursor = Cursors.Default;
            _controlStyleApplier.Apply(_textBox, _regularStyle);
        }
    }
}
