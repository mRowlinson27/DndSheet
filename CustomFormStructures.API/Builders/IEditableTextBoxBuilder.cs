using System.Collections.Generic;
using CustomFormManipulation.API.DTOs;
using CustomForms.API;

namespace CustomFormStructures.API.Builders
{
    public interface IEditableTextBoxBuilder
    {
        IEditableTextBox Build(string data, IControlStyle inEditDict, IControlStyle notInDict);
    }
}
