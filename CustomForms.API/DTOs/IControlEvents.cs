using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomForms.API
{
    public interface IControlEvents
    {
        event EventHandler Click;
        event EventHandler MouseEnter;
        event EventHandler TextChanged;
        event EventHandler Enter;
    }
}
