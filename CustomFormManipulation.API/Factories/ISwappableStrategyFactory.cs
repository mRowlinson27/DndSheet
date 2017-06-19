using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API.DTOs;

namespace CustomFormManipulation.API.Factories
{
    public interface ISwappableStrategyFactory
    {
        ISwappableStrategy Create(IControlProperties regularStyle, IControlProperties inEditStyle);
    }
}
