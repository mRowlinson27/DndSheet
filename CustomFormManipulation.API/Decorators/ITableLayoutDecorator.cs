using CustomFormManipulation.API.DTOs;
using CustomForms.API.TableLayoutWrapper;

namespace CustomFormManipulation.API.Decorators
{
    public interface ITableLayoutDecorator
    {
        ITableLayoutWrapper Apply(ITableLayoutWrapper input);
    }
}
