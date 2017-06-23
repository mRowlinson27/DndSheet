using System.Windows.Forms;
using CustomForms.API.TableLayoutWrapper;

namespace CustomFormStructures.API
{
    public interface IVerticalScrollStrategy : IMessageFilter
    {
        ITableLayoutWrapper ExecuteOn(ITableLayoutWrapper input);
    }
}
