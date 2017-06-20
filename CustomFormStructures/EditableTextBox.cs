using System;
using System.Drawing;
using System.Windows.Forms;
using CustomFormManipulation.API;
using CustomFormManipulation.API.DTOs;
using CustomForms.API;
using CustomForms.API.DTOs;
using CustomFormStructures.API;

namespace CustomFormStructures
{
    public class EditableTextBox : IEditableTextBox
    {
        public Control TrueControl { get; set; }
        private EditableStatus _status = EditableStatus.Regular;
        public EditableStatus EditableStatus
        {
            get { return _status; }
            set
            {
                if (_status == EditableStatus.InEdit && value != EditableStatus.InEdit)
                {
                    EnterRegularMode();
                }
                else if (_status == EditableStatus.Regular && value != EditableStatus.Regular)
                {
                    EnterEditMode();
                }
                _status = value;
            }
        }
        public string Text
        {
            get { return _textBox.Text; }
            set { _textBox.Text = value; }
        }

        private ITextBoxWrapper _textBox;
        private ISwappableStrategy _swappableStrategy;

        public EditableTextBox(ITextBoxWrapper input, ISwappableStrategy swappableStrategy, EditableStatus regularMode = EditableStatus.Regular)
        {
            _textBox = input;
            TrueControl = _textBox.TrueControl;
            _swappableStrategy = swappableStrategy;
            _status = regularMode;
            if (_status == EditableStatus.Regular)
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
            Console.WriteLine("InEdit");
            _textBox.Enabled = true;
            _textBox.ReadOnly = false;
            _textBox.Cursor = Cursors.IBeam;
            _swappableStrategy.SwapTo(_textBox, false);
        }

        private void EnterRegularMode()
        {
            Console.WriteLine("Regular");
            _textBox.Enabled = false;
            _textBox.ReadOnly = true;
            _textBox.Cursor = Cursors.Default;
            _swappableStrategy.SwapTo(_textBox, true);
        }
    }
}
