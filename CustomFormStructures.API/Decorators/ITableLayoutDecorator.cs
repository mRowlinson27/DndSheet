using CustomForms.API.TableLayoutWrapper;

namespace CustomFormStructures.API.Decorators
{
    public interface ITableLayoutDecorator
    {
        ITableLayoutWrapper Apply(ITableLayoutWrapper input);
    }
}
