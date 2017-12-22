namespace WpfUI
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using API;
    using API.Dtos;
    using Factories;
    using Utilities.Implementation;
    using Utilities.Implementation.DAL;
    using ViewModels;
    using ViewModels.Helpers;
    using DictionaryTableView = Controls.DictionaryTableView;
    using MainWindow = Controls.MainWindow;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            var logger = new Logger(
                new FileWriter(new StreamWriterWrapperFactory()),
                new DateTimeWrapper());

            logger.LogMessage("Program started");

            var application = new App();
            application.InitializeComponent();

            var dictionaryTableFactory = new DictionaryTableFactory(logger);
            var mainWindow = new MainWindow()
            {
                Logger = logger,
                DictionaryTableFactory = dictionaryTableFactory
            };
            mainWindow.Initialize();

            application.Exit += (sender, args) => logger.LogMessage("Program closed");

            application.Run(mainWindow);
        }
    }
}
