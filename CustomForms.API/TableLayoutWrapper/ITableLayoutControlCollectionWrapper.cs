using System.Windows.Forms;

namespace CustomForms.API.TableLayoutWrapper
{
    public interface ITableLayoutControlCollectionWrapper
    {
        void Add(ITrueControl control);
        void Add(ITrueControl control, int col, int row);
    }
}
