using System;
using CustomForms.API;
using CustomForms.API.DTOs;

namespace CustomForms.DTOs
{
    public class ControlEventsStyle : IControlEvents
    {
        public event EventHandler Click;
        public event EventHandler MouseEnter;
        public event EventHandler TextChanged;
        public event EventHandler Enter;
    }
}
