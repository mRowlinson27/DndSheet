using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomForms.API
{
    public interface ITableLayoutControlCollectionWrapper
    {
        void Add(Control control);
        void Add(Control control, int col, int row);
    }
}
