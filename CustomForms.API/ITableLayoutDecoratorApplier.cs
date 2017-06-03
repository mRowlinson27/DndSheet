using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.API
{
    public interface ITableLayoutDecoratorApplier
    {
        ITableLayoutWrapper Create(List<ITableLayoutDecorator> decorators, List<ITableLayoutDecoratorArguments> args);
        ITableLayoutWrapper Apply(ITableLayoutWrapper input, List<ITableLayoutDecorator> decorators, List<ITableLayoutDecoratorArguments> args);
    }
}
