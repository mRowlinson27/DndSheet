using CustomForms.API.DTOs;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.API.Decorators
{
    public interface ITableLayoutDecorator
    {
        ITableLayoutWrapper Create(ITableLayoutDecoratorArguments args);
        ITableLayoutWrapper Apply(ITableLayoutWrapper input, ITableLayoutDecoratorArguments args);
    }
}
