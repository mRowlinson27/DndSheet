﻿using CustomFormManipulation.API.DTOs;
using CustomForms.API;
using CustomForms.API.DTOs;

namespace CustomForms.DTOs
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
