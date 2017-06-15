using System;
using CustomForms.API;

namespace CustomForms.DTOs
{
    class ControlEventsStyle : IControlEvents
    {
        public event EventHandler Click;
        public event EventHandler MouseEnter;
        public event EventHandler TextChanged;
        public event EventHandler Enter;
    }
}
