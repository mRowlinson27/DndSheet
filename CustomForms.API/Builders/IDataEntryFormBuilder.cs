using System.Collections.Generic;
using System.Windows.Forms;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.API.Builders
{
    public interface IDataEntryFormBuilder
    {
        ITableLayoutWrapper Build(List<Control> controls);
    }
}
