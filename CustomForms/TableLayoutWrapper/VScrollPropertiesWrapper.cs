using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.TableLayoutWrapper
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
            get => _vScrollProperties.Maximum;
            set => _vScrollProperties.Maximum = value;
        }

        public bool Visible
        {
            get => _vScrollProperties.Visible;
            set => _vScrollProperties.Visible = value;
        }
    }
}
