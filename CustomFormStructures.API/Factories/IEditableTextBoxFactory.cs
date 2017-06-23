using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API;
using CustomForms.API.DTOs;

namespace CustomFormStructures.API.Factories
{
    public interface IEditableTextBoxFactory
    {
        IEditableTextBox Create(ITextBoxWrapper input, ISwappableTextboxStrategy swappableTextboxStrategy, EditableStatus regularMode = EditableStatus.Regular);
    }
}
