using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.TableLayoutWrapper
{
    class HScrollPropertiesWrapper : IHScrollPropertiesWrapper
    {
        private HScrollProperties _horizontalScroll;

        public HScrollPropertiesWrapper(HScrollProperties horizontalScroll)
        {
            _horizontalScroll = horizontalScroll;
        }

        public int Maximum
        {
            get => _horizontalScroll.Maximum;
            set => _horizontalScroll.Maximum = value;
        }

        public bool Visible
        {
            get => _horizontalScroll.Visible;
            set => _horizontalScroll.Visible = value;
        }
    }
}
