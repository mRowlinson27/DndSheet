using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API;

namespace CustomForms
{
    public class TableLayoutDecoratorApplier : ITableLayoutDecoratorApplier
    {
        public ITableLayoutWrapper Apply(ITableLayoutWrapper input, List<ITableLayoutDecorator> decorators)
        {
            ITableLayoutWrapper output = input;

            foreach (var decorator in decorators)
            {
                output = decorator.Apply(output);
            }
            return output;
        }

        public ITableLayoutWrapper Create(List<ITableLayoutDecorator> decorators)
        {
            var input = new TableLayoutWrapper.TableLayoutWrapper();
            return Apply(input, decorators);
        }
    }
}
