using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API;
using CustomForms.API.Factories;

namespace CustomForms.Factories
{
    public class EditableTextBoxFactory : IEditableTextBoxFactory
    {
        private ILabelWrapperFactory _labelWrapperFactory;
        public EditableTextBoxFactory(ILabelWrapperFactory labelWrapperFactory)
        {
            _labelWrapperFactory = labelWrapperFactory;
        }

        public IEditableTextBox Create(string data)
        {
            return new EditableTextBox(_labelWrapperFactory.Create(data));
        }
    }
}
