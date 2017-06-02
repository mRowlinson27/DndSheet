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
        public TableLayoutPanel Apply(TableLayoutPanel input, List<ITableLayoutDecorator> decorators)
        {
            TableLayoutPanel output = input;

            foreach (var decorator in decorators)
            {
                output = decorator.Apply(output);
            }
            return output;
        }

        public TableLayoutPanel Create(List<ITableLayoutDecorator> decorators)
        {
            var input = new TableLayoutPanel();
            return Apply(input, decorators);
        }
    }
}
