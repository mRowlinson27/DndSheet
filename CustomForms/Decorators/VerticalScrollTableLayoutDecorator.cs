using CustomForms.API;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.Decorators
{
    public class VerticalScrollTableLayoutDecorator : ITableLayoutDecorator
    {
        public ITableLayoutWrapper Create()
        {
            var input = new TableLayoutWrapper.TableLayoutWrapper();
            return ApplyChanges(input);
        }

        public ITableLayoutWrapper Apply(ITableLayoutWrapper input)
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
