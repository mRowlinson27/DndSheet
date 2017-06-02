using System.Collections.Generic;
using System.Windows.Forms;
using CustomForms.API;

namespace DnDCharacterSheet
{
    public class DataEntryFormBuilder : IDataEntryFormBuilder
    {
        public TableLayoutPanel Create()
        {
            var panel = new DataEntryForm(2, 3);
            panel.AddRow(new List<object>()
            {
                "boo",
                "meow",
                "go"
            });
            panel.AddRow(new List<object>()
            {
                "boo",
                "meow",
                "go"
            });
            panel.AddRow(new List<object>()
            {
                "boo",
                "meow",
                "go"
            });
            panel.AddRow(new List<object>()
            {
                "boo",
                "meow",
                "go"
            });
            panel.AddRow(new List<object>()
            {
                "boo",
                "meow",
                "go"
            });
            return panel;
        }
    }
}