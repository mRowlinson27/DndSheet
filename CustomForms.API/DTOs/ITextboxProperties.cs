using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomForms.API.DTOs
{
    public interface ITextBoxProperties : IControlProperties
    {
        bool ReadOnly { get; set; }
    }
}
