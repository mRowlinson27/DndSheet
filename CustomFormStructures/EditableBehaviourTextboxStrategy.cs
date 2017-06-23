using System;
using System.Drawing;
using System.Windows.Forms;
using CustomFormManipulation.API;
using CustomForms.API;
using CustomForms.API.DTOs;
using CustomFormStructures.API;
using DataManipulation.API;

namespace CustomFormStructures
{
    public class EditableBehaviourTextboxStrategy : ISwappableTextboxStrategy
    {
        private IPropertyApplier<ITextboxProperties> _propertyApplier;
        private ITextboxProperties _regularProperties;
        private ITextboxProperties _inEditProperties;
        public EditableBehaviourTextboxStrategy(IPropertyApplier<ITextboxProperties> propertyApplier, ITextboxProperties regularProperties, ITextboxProperties inEditProperties)
        {
            _propertyApplier = propertyApplier;
            _regularProperties = regularProperties;
            _inEditProperties = inEditProperties;
        }

        public ITextBoxWrapper SwapTo(ITextBoxWrapper control, bool regularMode)
        {
            ITextBoxWrapper output;
            if (regularMode)
            {
                control.Enter += OnEnter;
                control.TextChanged -= OnTextChanged;
                output = _propertyApplier.Apply(control, _regularProperties) as ITextBoxWrapper;
                OnTextChanged(output, null);
            }
            else
            {
                control.Enter -= OnEnter;
                control.TextChanged += OnTextChanged;
                output = _propertyApplier.Apply(control, _inEditProperties) as ITextBoxWrapper;
            }
            return output;
        }

        protected void OnEnter(object sender, System.EventArgs e)
        {
            var control = sender as Control;
            if (control != null) control.Parent.Parent.Focus();
        }

        protected void OnTextChanged(object sender, System.EventArgs e)
        {
            var control = sender as IControl;
            if (control != null)
            {
                Size size = TextRenderer.MeasureText(control.Text, control.Font);
                control.Width = (int)Math.Ceiling(((float)size.Width) + 10);
            }
        }
    }
}
