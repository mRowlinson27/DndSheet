using System.Collections.Generic;
using CustomForms.API.TableLayoutWrapper;

namespace CustomFormStructures.API.Decorators
{
    public interface ITableLayoutDecoratorApplier
    {
        ITableLayoutWrapper Apply(ITableLayoutWrapper input, List<ITableLayoutDecorator> decorators);
    }
}
