using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnDCharacterSheet
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainForm = new MainForm();
            var mainFormProcessor = new MainFormProcessor(mainForm.MainLayoutPanel, new CentralLayoutPanelFactory(), new DataEntryFormBuilder());
            mainForm.MainFormProcessor = mainFormProcessor;
            Application.Run(mainForm);
        }
    }
}
