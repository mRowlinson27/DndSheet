using System.Windows.Forms;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.TableLayoutWrapperFields
{
    public class TableLayoutRowStyleCollectionWrapper : ITableLayoutRowStyleCollectionWrapper
    {
        private TableLayoutRowStyleCollection _rowStyles;

        public TableLayoutRowStyleCollectionWrapper(TableLayoutRowStyleCollection rowStyles)
        {
            _rowStyles = rowStyles;
        }

        public void Add(RowStyle rowStyle)
        {
            _rowStyles.Add(rowStyle);
        }

        public int Count
        {
            get => _rowStyles.Count;
        }
    }
}
