using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API;

namespace CustomForms
{
    class TextBoxWrapper : TextBox, ITextBoxWrapper
    {
        public Control TrueControl => this;
    }
}
