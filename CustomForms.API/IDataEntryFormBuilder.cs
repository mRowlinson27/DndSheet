using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.API
{
    public interface IDataEntryFormBuilder
    {
        ITableLayoutWrapper Create(List<Control> controls);
    }
}
