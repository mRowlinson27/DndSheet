using System.Collections.Generic;
using CustomForms.API.DTOs;

namespace CustomForms.API.Builders
{
    public interface IEditableTextBoxBuilder
    {
        IEditableTextBox Build(string data, Dictionary<string, object> inEditDict,
            Dictionary<string, object> notInDict);
    }
}
