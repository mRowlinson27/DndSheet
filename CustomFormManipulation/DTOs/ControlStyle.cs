using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomFormManipulation.API.DTOs;
using CustomForms.API;

namespace CustomFormManipulation.DTOs
{
    public class ControlStyle : IControlStyle
    {
        public IControlProperties ControlProperties { get; }
        public IControlEvents ControlEvents { get; }
        public ControlStyle(IControlProperties controlProperties, IControlEvents controlEvents)
        {
            ControlProperties = controlProperties;
            ControlEvents = controlEvents;
        }
    }
}
