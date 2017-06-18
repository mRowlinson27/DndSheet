using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CustomFormManipulation;
using CustomFormManipulation.API.Decorators;
using CustomFormManipulation.Builders;
using CustomFormManipulation.Decorators;
using CustomForms;
using CustomForms.API;
using CustomForms.API.DTOs;
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
            var centralLayoutBuilderDecorators = new List<ITableLayoutDecorator>
            {
                new EqualColumnsTableLayoutDecorator(2)
            };
            var centralLayoutBuilder = new CentralLayoutBuilder(new TableLayoutDecoratorApplier(), centralLayoutBuilderDecorators, tableLayoutWrapperFactory);

            var textBoxStyleApplier = new ControlStyleApplier(new PropertyApplier<IControlProperties>(), new EventApplier<IControlEvents>());

            var dataEntryFormManager = new DataEntryFormManager(
                new DataEntryFormBuilder(tableLayoutWrapperFactory),
                new DataMapper(new EditableTextBoxBuilder(new TextBoxWrapperFactory(), textBoxStyleApplier), new ControlStyleFactory()));

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
