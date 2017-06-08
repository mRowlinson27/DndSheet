using System.Windows.Forms;
using CustomForms.API.TableLayoutWrapper;

namespace CustomForms.API.Builders
{
    public interface ICentralLayoutBuilder
    {
        ITableLayoutWrapper Build();
    }
}