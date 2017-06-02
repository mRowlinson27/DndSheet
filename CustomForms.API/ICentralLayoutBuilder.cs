using System.Windows.Forms;

namespace DnDCharacterSheet
{
    public interface ICentralLayoutBuilder
    {
        TableLayoutPanel Create();
    }
}