using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomFormManipulation.API.DTOs;
using CustomForms.API.DTOs;

namespace CustomForms.API.Factories
{
    public interface IControlPropertiesFactory
    {
        IControlPropertiesStyle Create();
        ITextBoxPropertiesStyle CreateTextboxInEditStyle();
        ITextBoxPropertiesStyle CreateTextboxRegularStyle();
    }
}
