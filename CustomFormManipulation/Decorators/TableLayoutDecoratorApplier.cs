using System.Collections.Generic;
using CustomFormManipulation.API.Decorators;
using CustomForms.API.TableLayoutWrapper;

namespace CustomFormManipulation.Decorators
{
    public class TableLayoutDecoratorApplier : ITableLayoutDecoratorApplier
    {
        public ITableLayoutWrapper Apply(ITableLayoutWrapper input, List<ITableLayoutDecorator> decorators)
        {
            ITableLayoutWrapper output = input;

            for (var i = 0; i < decorators.Count; i++ )
            {
                output = decorators[i].Apply(output);
            }
            return output;
        }
    }
}
