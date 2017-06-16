using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomFormManipulation.API;
using CustomFormManipulation.API.DTOs;
using CustomForms.API;
using DataManipulation.API;

namespace CustomFormManipulation
{
    public class ControlStyleApplier : IControlStyleApplier
    {
        private IPropertyApplier<IControlProperties> _propertyApplier;
        private IEventApplier<IControlEvents> _eventApplier;
        public ControlStyleApplier(IPropertyApplier<IControlProperties> propertyApplier, IEventApplier<IControlEvents> eventApplier)
        {
            _propertyApplier = propertyApplier;
            _eventApplier = eventApplier;
        }

        public IControl Apply(IControl input, IControlStyle style)
        {
            var output = input.RemoveAllEvents();
            output = _propertyApplier.Apply(input, style.ControlProperties) as IControl;
            output = _eventApplier.Apply(input, style.ControlEvents) as IControl;
            return output;
        }
    }
}
