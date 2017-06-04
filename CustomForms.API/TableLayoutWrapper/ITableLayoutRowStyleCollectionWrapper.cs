using System.Windows.Forms;

namespace CustomForms.API.TableLayoutWrapper
{
    public interface ITableLayoutRowStyleCollectionWrapper
    {
        void Add(RowStyle rowStyle);
        int Count { get; }
    }
}
