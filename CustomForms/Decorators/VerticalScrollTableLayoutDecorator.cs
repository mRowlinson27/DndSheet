using CustomForms.API;
using CustomForms.API.Decorators;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.Decorators
{
    public class VerticalScrollTableLayoutDecorator : ITableLayoutDecorator
    {
        public ITableLayoutWrapper Create(ITableLayoutDecoratorArguments args)
        {
            var input = new TableLayoutWrapper.TableLayoutWrapper();
            return ApplyChanges(input);
        }

        public ITableLayoutWrapper Apply(ITableLayoutWrapper input, ITableLayoutDecoratorArguments args)
        {
            return ApplyChanges(input);
        }

        private ITableLayoutWrapper ApplyChanges(ITableLayoutWrapper input)
        {
            input.AutoScroll = false;
            input.AccessHorizontalScroll.Maximum = 0;
            input.AccessVerticalScroll.Visible = false;
            input.AccessHorizontalScroll.Visible = false;
            input.AutoScroll = true;
            return input;
        }
    }
}
