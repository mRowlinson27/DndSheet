using System.Collections.Generic;
using CustomFormManipulation.API.DTOs;
using CustomForms.API.TableLayoutWrapper;

namespace CustomFormManipulation.API.Decorators
{
    public interface ITableLayoutDecoratorApplier
    {
        ITableLayoutWrapper Apply(ITableLayoutWrapper input, List<ITableLayoutDecorator> decorators, List<ITableLayoutDecoratorArguments> args);
    }
}
