using System.Windows.Forms;
using CustomForms.API;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.TableLayoutWrapperFields
{
    class TableLayoutControlCollectionWrapper : ITableLayoutControlCollectionWrapper
    {
        private TableLayoutControlCollection _control;

        public TableLayoutControlCollectionWrapper(TableLayoutControlCollection control)
        {
            _control = control;
        }

        public void Add(IControl control)
        {
            Add(control.TrueControl);
        }

        public void Add(IControl control, int row, int col)
        {
            Add(control.TrueControl, col - 1, row - 1);
        }

        public void Add(Control control)
        {
            _control.Add(control);
        }

        public void Add(Control control, int col, int row)
        {
            _control.Add(control, col, row);
        }
    }
}
