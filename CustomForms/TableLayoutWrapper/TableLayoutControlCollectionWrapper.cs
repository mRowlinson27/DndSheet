using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API;

namespace CustomForms.TableLayoutWrapper
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

        public void Add(IControl control, int col, int row)
        {
            Add(control.TrueControl, col, row);
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
