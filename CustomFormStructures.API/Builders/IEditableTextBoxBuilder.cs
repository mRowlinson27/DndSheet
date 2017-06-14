using System.Collections.Generic;
using CustomForms.API;

namespace CustomFormStructures.API.Builders
{
    public interface IEditableTextBoxBuilder
    {
        IEditableTextBox Build(string data, IControlProperties inEditDict, IControlProperties notInDict);
    }
}
