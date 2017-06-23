using System.Windows.Forms;
using CustomForms.API.TableLayoutWrapper;
using CustomFormStructures.API.Decorators;

namespace CustomFormStructures.Decorators
{
    public class EqualColumnsTableLayoutDecorator : ITableLayoutDecorator
    {
        private int _numCols;

        public EqualColumnsTableLayoutDecorator(int numCols)
        {
            _numCols = numCols;
        }

        public ITableLayoutWrapper Apply(ITableLayoutWrapper input)
        {
            return ApplyChanges(input);
        }

        private ITableLayoutWrapper ApplyChanges(ITableLayoutWrapper input)
        {
            float diviser = 100 / _numCols;
            for (var i = 0; i < _numCols; i++)
            {
                input.AccessColumnStyles.Add(new ColumnStyle(SizeType.Percent, diviser));
            }
            input.ColumnCount = input.AccessColumnStyles.Count;
            return input;
        }
    }
}
