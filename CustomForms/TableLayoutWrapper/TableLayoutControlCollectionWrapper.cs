using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API;

namespace CustomForms.TableLayoutWrapper
{
    class TableLayoutControlCollectionWrapper : TableLayoutControlCollection, ITableLayoutControlCollectionWrapper
    {
        public TableLayoutControlCollectionWrapper(TableLayoutPanel container) : base(container)
        {
        }

        public void Add(IControl tableLayoutWrapper)
        {
            throw new NotImplementedException();
        }

        public void Add(IControl tableLayoutWrapper, int col, int row)
        {
            throw new NotImplementedException();
        }
    }
}
