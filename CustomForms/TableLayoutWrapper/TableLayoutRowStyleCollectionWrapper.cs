using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.TableLayoutWrapper
{
    public class TableLayoutRowStyleCollectionWrapper : ITableLayoutRowStyleCollectionWrapper
    {
        private TableLayoutRowStyleCollection _rowStyles;

        public TableLayoutRowStyleCollectionWrapper(TableLayoutRowStyleCollection rowStyles)
        {
            _rowStyles = rowStyles;
        }

        public int Count
        {
            get => _rowStyles.Count;
        }
    }
}
