using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomForms.API
{
    public interface ITextBoxWrapper : IControl
    {

        bool ReadOnly { get; set; }
    }
}
