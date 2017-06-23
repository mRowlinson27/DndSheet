using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API;
using CustomForms.API.DTOs;
using CustomFormStructures.API;
using CustomFormStructures.API.Factories;

namespace CustomFormStructures.Factories
{
    public class EditableTextBoxFactory : IEditableTextBoxFactory
    {
        public IEditableTextBox Create(ITextBoxWrapper input, ISwappableTextboxStrategy swappableTextboxStrategy,
            EditableStatus regularMode = EditableStatus.Regular)
        {
            return new EditableTextBox(input, swappableTextboxStrategy, regularMode);
        }
    }
}
