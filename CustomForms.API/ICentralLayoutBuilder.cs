using System.Windows.Forms;
using CustomForms.API;
using CustomForms.API.TableLayoutWrapper;

namespace DnDCharacterSheet
{
    public interface ICentralLayoutBuilder
    {
        ITableLayoutWrapper Create();
    }
}