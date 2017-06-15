using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomFormManipulation.API;
using DataManipulation.API;

namespace CustomFormManipulation
{
    public class ControlStyleApplier<T> : IControlStyleApplier<T>
    {
        private IPropertyApplier<T> _propertyApplier;
        public ControlStyleApplier(IPropertyApplier<T> propertyApplier)
        {
            _propertyApplier = propertyApplier;
        }

        public T Apply(T input, T style)
        {
            return _propertyApplier.Apply(input, style);
        }
    }
}
