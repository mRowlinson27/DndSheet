using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API;

namespace CustomFormManipulation.API.DTOs
{
    public interface IControlStyle
    {
        IControlProperties ControlProperties { get; }
        IControlEvents ControlEvents { get; }
    }
}
