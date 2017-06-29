using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManipulation.API
{
    public interface IPropertyChangedChecker
    {
        bool HasPropertyChanged(string property);
    }
}
