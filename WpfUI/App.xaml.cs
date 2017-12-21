namespace WpfUI
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
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

            var dictionaryTable = new DictionaryTable()
            {
                Headings = new List<ColumnHeadings>
                {
                    new ColumnHeadings()
                    {
                        ColumnType = typeof(string),
                        HeadingName = "Skill Name"
                    },
                    new ColumnHeadings()
                    {
                        ColumnType = typeof(bool),
                        HeadingName = "Description"
                    },
                    new ColumnHeadings()
                    {
                        ColumnType = typeof(int),
                        HeadingName = "Ranks"
                    }
                },
                Rows = new List<Dictionary<string, object>>
                {
                    new Dictionary<string, object>
                    {
                        {"Skill Name", "Acro"},
                        {"Description",  true},
                        {"Ranks", 1}
                    },
                    new Dictionary<string, object>
                    {
                        {"Skill Name", "Climb"},
                        {"Description",  false},
                        {"Ranks", 3}
                    }
                }
            };

            var tablesView = new DictionaryTableFactory().Create(dictionaryTable);

            var mainWindow = new MainWindow
            {
                DataContext = new MainViewModel(tablesView)
            };

            application.Exit += (sender, args) => logger.LogMessage("Program closed");

            application.Run(mainWindow);
        }
    }
}
