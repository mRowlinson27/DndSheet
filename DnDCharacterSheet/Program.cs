using System;
using System.Windows.Forms;
using CustomFormManipulation;
using CustomFormManipulation.Builders;
using CustomFormManipulation.Decorators;
using CustomForms;
using CustomForms.Factories;
using CustomFormStructures.Builders;
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

            var tableLayoutWrapperFactory = new TableLayoutWrapperFactory();
            var centralLayoutBuilder = new CentralLayoutBuilder(new TableLayoutDecoratorApplier(), tableLayoutWrapperFactory);

            var dataEntryFormManager = new DataEntryFormManager(
                new DataEntryFormBuilder(tableLayoutWrapperFactory),
                new DataMapper(new EditableTextBoxBuilder(new TextBoxWrapperFactory())));

            var verticalScrollStrategy = new VerticalScrollStrategy(new Win32Adapter(new NativeMethods()));

            var mainFormProcessor = new MainFormProcessor(mainForm.MainLayoutPanel,
                centralLayoutBuilder,
                dataEntryFormManager,
                verticalScrollStrategy);

            mainForm.MainFormProcessor = mainFormProcessor;
            mainFormProcessor.SetUpStatPage();

            Application.Run(mainForm);
        }
    }
}
