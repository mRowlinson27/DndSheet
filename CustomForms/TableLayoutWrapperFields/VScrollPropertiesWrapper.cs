using System.Windows.Forms;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.TableLayoutWrapperFields
{
    class VScrollPropertiesWrapper : IVScrollPropertiesWrapper
    {
        private VScrollProperties _vScrollProperties;
        public VScrollPropertiesWrapper(VScrollProperties vScrollProperties)
        {
            _vScrollProperties = vScrollProperties;
        }

        public int Maximum
        {
            get { return _vScrollProperties.Maximum; }
            set { _vScrollProperties.Maximum = value; }
        }

        public bool Visible
        {
            get { return _vScrollProperties.Visible; }
            set { _vScrollProperties.Visible = value; }
        }
    }
}
