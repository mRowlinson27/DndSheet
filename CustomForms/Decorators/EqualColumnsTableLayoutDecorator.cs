using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API;
using CustomForms.API.Decorators;
using CustomForms.API.DTOs;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.Decorators
{
    public class EqualColumnsTableLayoutDecorator : ITableLayoutDecorator
    {
        private EqualColumnsTableLayoutDecoratorArgs _args;
        public ITableLayoutWrapper Create(ITableLayoutDecoratorArguments args)
        {
            var input = new TableLayoutWrapperFields.TableLayoutWrapper();
            _args = args as EqualColumnsTableLayoutDecoratorArgs;
            return ApplyChanges(input);
        }

        public ITableLayoutWrapper Apply(ITableLayoutWrapper input, ITableLayoutDecoratorArguments args)
        {
            _args = args as EqualColumnsTableLayoutDecoratorArgs;
            return ApplyChanges(input);
        }

        private ITableLayoutWrapper ApplyChanges(ITableLayoutWrapper input)
        {
            float diviser = 100 / _args.NumCols;
            for (var i = 0; i < _args.NumCols; i++)
            {
                input.AccessColumnStyles.Add(new ColumnStyle(SizeType.Percent, diviser));
            }
            input.ColumnCount = input.AccessColumnStyles.Count;
            return input;
        }
    }
}
