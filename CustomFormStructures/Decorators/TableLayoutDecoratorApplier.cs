using System.Collections.Generic;
using CustomForms.API.TableLayoutWrapper;
using CustomFormStructures.API.Decorators;

namespace CustomFormStructures.Decorators
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
