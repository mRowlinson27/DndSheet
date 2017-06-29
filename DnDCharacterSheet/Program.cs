using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CustomFormManipulation;
using CustomForms;
using CustomForms.API;
using CustomForms.API.DTOs;
using CustomForms.Factories;
using CustomFormStructures;
using CustomFormStructures.API.Decorators;
using CustomFormStructures.Builders;
using CustomFormStructures.Decorators;
using CustomFormStructures.Factories;
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

            var textBoxStyleApplier = new PropertyApplier<ITextBoxProperties>();

            var dataEntryFormManager = new DataEntryFormManager(
                new DataEntryFormBuilder(tableLayoutWrapperFactory),
                new DataMapper(new EditableTextBoxBuilder(new TextBoxWrapperFactory(), new SwappableStrategyFactory(textBoxStyleApplier), new EditableTextBoxFactory()), new ControlPropertiesFactory()));

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
