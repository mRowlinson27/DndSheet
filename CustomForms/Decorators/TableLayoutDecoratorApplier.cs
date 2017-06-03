using System.Collections.Generic;
using CustomForms.API;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.Decorators
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
