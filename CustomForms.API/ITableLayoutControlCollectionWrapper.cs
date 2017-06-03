using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomForms.API
{
    public interface ITableLayoutControlCollectionWrapper
    {
        void Add(IControl tableLayoutWrapper);
        void Add(IControl tableLayoutWrapper, int col, int row);
    }
}
