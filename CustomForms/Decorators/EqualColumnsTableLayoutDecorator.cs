using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.Decorators
{
    class EqualColumnsTableLayoutDecorator : ITableLayoutDecorator
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
            return input;
        }
    }
}
