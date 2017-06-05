using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms;
using CustomForms.Builders;
using CustomForms.Decorators;
using CustomForms.Factories;
using DataManipulation;
using FormApp;

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
            var mainFormProcessor = new MainFormProcessor(
                mainForm.MainLayoutPanel,
                new CentralLayoutBuilder(new TableLayoutDecoratorApplier()),
                new DataEntryFormManager(new TableLayoutBuilder(), new DataMapper(new LabelWrapperFactory())));

            mainForm.MainFormProcessor = mainFormProcessor;
            mainFormProcessor.SetUpStatPage();

            Application.Run(mainForm);
        }
    }
}
