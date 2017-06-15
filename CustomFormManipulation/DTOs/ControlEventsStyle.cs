using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API;

namespace CustomFormManipulation.DTOs
{
    class ControlEventsStyle : IControlEvents
    {
        public event EventHandler Click;
        public event EventHandler MouseEnter;
    }
}
