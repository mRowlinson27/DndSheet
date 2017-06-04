using System.Windows.Forms;

namespace CustomForms.API.TableLayoutWrapper
{
    public interface ITableLayoutControlCollectionWrapper
    {
        void Add(IControl control);
        void Add(IControl control, int col, int row);
    }
}
