using System.Collections.Generic;
using CustomForms.API;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.Decorators
{
    public class TableLayoutDecoratorApplier : ITableLayoutDecoratorApplier
    {
        public ITableLayoutWrapper Apply(ITableLayoutWrapper input, List<ITableLayoutDecorator> decorators, List<ITableLayoutDecoratorArguments> args)
        {
            ITableLayoutWrapper output = input;

            for (var i = 0; i < decorators.Count; i++ )
            {
                output = decorators[i].Apply(output, args[i]);
            }
            return output;
        }

        public ITableLayoutWrapper Create(List<ITableLayoutDecorator> decorators, List<ITableLayoutDecoratorArguments> args)
        {
            var input = new TableLayoutWrapper.TableLayoutWrapper();
            return Apply(input, decorators, args);
        }
    }
}
