using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomForms.API.TableLayoutWrapper
{
    public interface IVScrollPropertiesWrapper
    {
        int Maximum { get; set; }
        bool Visible { get; set; }
    }
}
