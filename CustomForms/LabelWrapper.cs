using System.Windows.Forms;
using CustomForms.API;

namespace CustomForms
{
    public class LabelWrapper : Label, ILabelWrapper
    {
        public Control TrueControl => this;
    }
}