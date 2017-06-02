using System.Windows.Forms;
using CustomForms.API;

namespace DnDCharacterSheet
{
    public interface ICentralLayoutBuilder
    {
        ITableLayoutWrapper Create();
    }
}