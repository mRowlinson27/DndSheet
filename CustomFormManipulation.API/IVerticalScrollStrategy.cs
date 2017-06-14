using System.Windows.Forms;
using CustomForms.API.TableLayoutWrapper;

namespace CustomFormManipulation.API
{
    public interface IVerticalScrollStrategy : IMessageFilter
    {
        ITableLayoutWrapper ExecuteOn(ITableLayoutWrapper input);
    }
}
