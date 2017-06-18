using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomFormManipulation.API;
using CustomFormManipulation.API.DTOs;
using CustomForms.API;
using CustomForms.API.DTOs;
using DataManipulation.API;

namespace CustomFormManipulation
{
    public class EditableBehaviourStrategy
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

        public IControl Apply(IControl input, IControlStyle style)
        {
            var output = _propertyApplier.Apply(input, style.ControlProperties) as IControl;
            return output;
        }
    }
}
