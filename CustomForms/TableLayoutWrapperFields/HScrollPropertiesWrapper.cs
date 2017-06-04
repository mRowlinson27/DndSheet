using System.Windows.Forms;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.TableLayoutWrapperFields
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
            get { return _horizontalScroll.Maximum; }
            set { _horizontalScroll.Maximum = value; }
        }

        public bool Visible
        {
            get { return _horizontalScroll.Visible; }
            set { _horizontalScroll.Visible = value; }
        }
    }
}
