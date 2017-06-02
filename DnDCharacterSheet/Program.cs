﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms;

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
            var mainFormProcessor = new MainFormProcessor(new TableLayoutWrapper(mainForm.MainLayoutPanel), new CentralLayoutBuilder(new TableLayoutDecoratorApplier()), new DataEntryFormBuilder());
            mainForm.MainFormProcessor = mainFormProcessor;
            Application.Run(mainForm);
        }
    }
}
