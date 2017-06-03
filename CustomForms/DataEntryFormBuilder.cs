using System.Collections.Generic;
using System.Windows.Forms;
using CustomForms.API;
using CustomForms.API.TableLayoutWrapper;

namespace DnDCharacterSheet
{
    public class DataEntryFormBuilder : IDataEntryFormBuilder
    {
        public ITableLayoutWrapper Create(List<Control> controls)
        {
            var panel = new DataEntryForm(4, 3, 20);
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