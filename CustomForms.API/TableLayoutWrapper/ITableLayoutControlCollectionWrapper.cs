using System.Windows.Forms;

namespace CustomForms.API.TableLayoutWrapper
{
    public interface ITableLayoutControlCollectionWrapper
    {
        void Add(Control control);
        void Add(Control control, int col, int row);
    }
}
