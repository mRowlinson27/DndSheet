using System;
using System.Drawing;
using System.Windows.Forms;
using CustomFormManipulation.API;
using CustomForms.API.DTOs;
using CustomFormStructures.API;
using DataManipulation.API;

namespace CustomFormStructures
{
    public class EditableBehaviourStrategy : ISwappableStrategy
    {
        private IPropertyApplier<IControlProperties> _propertyApplier;
        private IControlProperties _regularProperties;
        private IControlProperties _inEditProperties;
        public EditableBehaviourStrategy(IPropertyApplier<IControlProperties> propertyApplier, IControlProperties regularProperties, IControlProperties inEditProperties)
        {
            _propertyApplier = propertyApplier;
            _regularProperties = regularProperties;
            _inEditProperties = inEditProperties;
        }

        public IControl SwapTo(IControl control, bool regularMode)
        {
            IControl output;
            if (regularMode)
            {
                control.Enter += OnEnter;
                control.TextChanged -= OnTextChanged;
                output = _propertyApplier.Apply(control, _regularProperties) as IControl;
            }
            else
            {
                control.Enter -= OnEnter;
                control.TextChanged += OnTextChanged;
                output = _propertyApplier.Apply(control, _inEditProperties) as IControl;
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
