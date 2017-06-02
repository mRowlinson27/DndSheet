using System.Windows.Forms;
using CustomForms.API;

namespace DnDCharacterSheet
{
    public class DataEntryFormBuilder : IDataEntryFormBuilder
    {
        public TableLayoutPanel Create()
        {
            return new DataEntryForm(3);
        }
    }
}