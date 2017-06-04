using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API;
using CustomForms.API.Factories;

namespace CustomForms.Factories
{
    public class LabelWrapperFactory : ILabelWrapperFactory
    {
        public ILabelWrapper Create(string data)
        {
            return new LabelWrapper() {Text = data, Height = 20, AutoSize = true};
        }
    }
}
