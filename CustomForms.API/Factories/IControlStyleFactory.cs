using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomFormManipulation.API.DTOs;

namespace CustomForms.API.Factories
{
    public interface IControlStyleFactory
    {
        IControlStyle Create();
        IControlStyle CreateInEditStyle();
        IControlStyle CreateRegularStyle();
    }
}
