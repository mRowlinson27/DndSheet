
namespace WpfUI.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using API.Dtos;
    using FakeItEasy;
    using FluentAssertions;
    using NUnit.Framework;
    using ViewModels.Helpers;
    using ILogger = Utilities.API.ILogger;

    [TestFixture]
    class DictionaryTableViewModelHelperTests
    {
        private DictionaryTableViewModelHelper _dictionaryTableViewModelHelper;

        [SetUp]
        public void Setup()
        {
            var logger = A.Fake<ILogger>();
            _dictionaryTableViewModelHelper = new DictionaryTableViewModelHelper(logger);
        }

        [Test]
        public void ConvertDictionaryTableToDataTable_CorrectTableReturned()
        {
            //Arrange
            var data = GetDefaultDictionaryTable();

            //Act
            var result = _dictionaryTableViewModelHelper.ConvertDictionaryTableToDataTable(data);

            //Assert
            var defaultDataTable = GetDefaultDataTable();
            CompareDataTables(result, defaultDataTable);
        }

        [Test]
        public void ConvertDataTableToDictionaryTable_CorrectTableReturned()
        {
            //Arrange
            var defaultDataTable = GetDefaultDataTable();

            //Act
            var result = _dictionaryTableViewModelHelper.ConvertDataTableToDictionaryTable(defaultDataTable);

            //Assert
            var defaultDictionaryTable = GetDefaultDictionaryTable();
            CompareDictionaryTables(result, defaultDictionaryTable);
        }

        private DictionaryTable GetDefaultDictionaryTable()
        {
            return new DictionaryTable()
            {
                Headings = new List<ColumnHeading>
                {
                    new ColumnHeading()
                    {
                        ColumnType = typeof(string),
                        HeadingName = "Skill Name"
                    },
                    new ColumnHeading()
                    {
                        ColumnType = typeof(bool),
                        HeadingName = "Description"
                    },
                    new ColumnHeading()
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
        }

        private DataTable GetDefaultDataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Skill Name", typeof(string));
            dataTable.Columns.Add("Description", typeof(bool));
            dataTable.Columns.Add("Ranks", typeof(int));

            dataTable.Rows.Add("Acro", true, 1);
            dataTable.Rows.Add("Climb", false, 3);

            return dataTable;
        }

        private void CompareDictionaryTables(DictionaryTable table1, DictionaryTable table2)
        {
            Assert.That(table1.Headings.Count == table2.Headings.Count);
            for (int i = 0; i < table1.Headings.Count; i++)
            {
                var heading1 = table1.Headings[i];
                var heading2 = table2.Headings[i];
                heading1.ShouldBeEquivalentTo(heading2);
            }

            Assert.That(table1.Rows.Count == table2.Rows.Count);
            for (int i = 0; i < table1.Rows.Count; i++)
            {
                var row1 = table1.Rows[i];
                var row2 = table2.Rows[i];
                row1.ShouldBeEquivalentTo(row2);
            }
        }

        private void CompareDataTables(DataTable table1, DataTable table2)
        {
            Assert.That(table1.Columns.Count == table2.Columns.Count);
            Assert.That(table1.Rows.Count == table2.Rows.Count);
            for (int i = 0; i < table1.Columns.Count; i++)
            {
                var col1 = table1.Columns[i];
                var col2 = table2.Columns[i];
                col1.ColumnName.Should().BeEquivalentTo(col2.ColumnName);
                for (int j = 0; j < table1.Rows.Count; j++)
                {
                    var row1 = table1.Rows[j][col1.ColumnName];
                    var row2 = table2.Rows[j][col2.ColumnName];
                    row1.ShouldBeEquivalentTo(row2);
                }
            }
        }
    }
}
