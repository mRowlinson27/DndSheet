using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.API
{
    public interface IVerticalScrollStrategy
    {
        ITableLayoutWrapper ExecuteOn(ITableLayoutWrapper input);
    }
}
