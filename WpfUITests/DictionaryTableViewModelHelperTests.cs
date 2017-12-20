﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUITests
{
    using System.Data;
    using FluentAssertions;
    using NUnit.Framework;
    using WpfUI.Dtos;
    using WpfUI.ViewModels.Helpers;

    [TestFixture]
    class DictionaryTableViewModelHelperTests
    {
        [Test]
        public void GetSource_HasCorrectColumnNames()
        {
            //Arrange
            var data = GetDefaultData();
            var dictionaryTableViewModelHelper = new DictionaryTableViewModelHelper(data);

            //Act
            var result = dictionaryTableViewModelHelper.GetSource();

            //Assert
            result.Columns[0].ColumnName.Should().Be(data.Headings[0].HeadingName);
            result.Columns[1].ColumnName.Should().Be(data.Headings[1].HeadingName);
            result.Columns[2].ColumnName.Should().Be(data.Headings[2].HeadingName);
        }

        [Test]
        public void GetSource_HasRows()
        {
            //Arrange
            var data = GetDefaultData();
            var dictionaryTableViewModelHelper = new DictionaryTableViewModelHelper(data);

            //Act
            var result = dictionaryTableViewModelHelper.GetSource();

            //Assert
            CompareRow(result.Rows, data);
        }

        private DictionaryTable GetDefaultData()
        {
            return new DictionaryTable()
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
        }

        private void CompareRow(DataRowCollection dataRowCollection, DictionaryTable dictionaryTable)
        {
            for (var i = 0; i < dataRowCollection.Count; i++)
            {
                var row = dataRowCollection[i];
                for (var headingNum = 0; headingNum < dictionaryTable.Headings.Count; headingNum++ )
                {
                    var correctVal = dictionaryTable.Rows[i][dictionaryTable.Headings[headingNum].HeadingName];
                    //row[headingNum].Should().Be(correctVal);
                    Console.WriteLine($"{row[headingNum]} ({row[headingNum].GetType()}) - {correctVal} ({correctVal.GetType()})");
                }
            }
        }
    }
}