using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API.DTOs;

namespace CustomForms.DTOs
{
    class TextboxPropertiesStyle : ControlPropertiesStyle, ITextboxProperties
    {
        public bool ReadOnly { get; set; }
    }
}
