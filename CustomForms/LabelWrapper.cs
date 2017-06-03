using System.Windows.Forms;
using CustomForms.API;

namespace CustomForms
{
    public class LabelWrapper : Label, ILabelWrapper
    {
        private Label _trueControl;

        public LabelWrapper()
        {
            _trueControl = new Label();
        }

        public int Height
        {
            get => _trueControl.Height;
            set => _trueControl.Height = value;
        }

        public int Width
        {
            get => _trueControl.Width;
            set => _trueControl.Width = value;
        }

        public Control TrueControl => _trueControl;
    }
}