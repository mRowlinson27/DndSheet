using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API;
using CustomForms.API.Factories;

namespace CustomForms.Factories
{
    public class TextBoxWrapperFactory : ITextBoxWrapperFactory
    {
        public ITextBoxWrapper Create()
        {
            return new TextBoxWrapper();
        }
    }
}
