using System.Collections.Generic;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.API.Decorators
{
    public interface ITableLayoutDecoratorApplier
    {
        ITableLayoutWrapper Create(List<ITableLayoutDecorator> decorators, List<ITableLayoutDecoratorArguments> args);
        ITableLayoutWrapper Apply(ITableLayoutWrapper input, List<ITableLayoutDecorator> decorators, List<ITableLayoutDecoratorArguments> args);
    }
}
