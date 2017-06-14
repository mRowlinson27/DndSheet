using System.Windows.Forms;
using CustomFormManipulation.API.Decorators;
using CustomFormManipulation.API.DTOs;
using CustomForms.API.TableLayoutWrapper;

namespace CustomFormManipulation.Decorators
{
    public class EqualColumnsTableLayoutDecorator : ITableLayoutDecorator
    {
        private EqualColumnsTableLayoutDecoratorArgs _args;
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
