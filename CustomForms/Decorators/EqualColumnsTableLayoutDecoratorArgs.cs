using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API;

namespace CustomForms.Decorators
{
    public class EqualColumnsTableLayoutDecoratorArgs : ITableLayoutDecoratorArguments
    {
        public int NumCols { get; set; }
    }
}
