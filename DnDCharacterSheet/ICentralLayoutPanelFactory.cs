using System.Windows.Forms;

namespace DnDCharacterSheet
{
    public interface ICentralLayoutPanelFactory
    {
        TableLayoutPanel Create();
    }
}