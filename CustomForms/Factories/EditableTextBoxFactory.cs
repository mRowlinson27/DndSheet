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
    public class EditableTextBoxFactory : IEditableTextBoxFactory
    {
        private ILabelWrapperFactory _labelWrapperFactory;
        public EditableTextBoxFactory(ILabelWrapperFactory labelWrapperFactory)
        {
            _labelWrapperFactory = labelWrapperFactory;
        }

        public IEditableTextBox Create(string data)
        {
            var creation = new TextBoxWrapper()
            {
                ReadOnly = true,
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.Left,
                Cursor = Cursors.Default,
                BorderStyle = BorderStyle.None,
                BackColor = Color.Transparent,
            };
            creation.TrueControl.Enter += OnEnter;
            creation.TrueControl.TextChanged += OnTextChanged;
            creation.Text = data;
            var creation2 = new LabelWrapperFactory().Create(data);
            return new EditableTextBox(creation);
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
