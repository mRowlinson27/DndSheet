using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomForms.API.Factories
{
    public interface ILabelWrapperFactory
    {
        ILabelWrapper Create(string data);
    }
}
