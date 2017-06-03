using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.API
{
    interface ITableLayoutFormatterStrategy
    {
        ITableLayoutWrapper Apply(ITableLayoutWrapper input, ITableLayoutDecoratorArguments args);
    }
}
