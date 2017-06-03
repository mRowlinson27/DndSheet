using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.TableLayoutWrapper
{
    public class TableLayoutColumnStyleCollectionWrapper : ITableLayoutColumnStyleCollectionWrapper
    {
        private TableLayoutColumnStyleCollection _columnStyles;
        public TableLayoutColumnStyleCollectionWrapper(TableLayoutColumnStyleCollection columnStyles)
        {
            _columnStyles = columnStyles;
        }

        public void Add(ColumnStyle columnStyle)
        {
            _columnStyles.Add(columnStyle);
        }

        public int Count => _columnStyles.Count;
    }
}
