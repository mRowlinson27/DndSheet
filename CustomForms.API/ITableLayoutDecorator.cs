using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomForms.API
{
    public interface ITableLayoutDecorator
    {
        ITableLayoutWrapper Create();
        ITableLayoutWrapper Apply(ITableLayoutWrapper input);
    }
}
