using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomForms.API
{
    public interface IDataEntryFormBuilder
    {
        TableLayoutPanel Create(List<Control> controls);
    }
}
