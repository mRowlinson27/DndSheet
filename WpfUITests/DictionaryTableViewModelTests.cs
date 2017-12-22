
namespace WpfUI.UnitTests
{
    using System;
    using System.Data;
    using API;
    using API.Dtos;
    using FakeItEasy;
    using FluentAssertions;
    using NUnit.Framework;
    using Utilities.API;
    using ViewModels;
    using ViewModels.Helpers;

    [TestFixture]
    public class DictionaryTableViewModelTests
    {
        private DictionaryTableViewModel _dictionaryTableViewModel;
        private IDictionaryTableView _dictionaryTableView;
        private IDictionaryTableViewModelHelper _dictionaryTableViewModelHelper;
        private ILogger _logger;

        [SetUp]
        public void Setup()
        {
            _dictionaryTableView = A.Fake<IDictionaryTableView>();
            _dictionaryTableViewModelHelper = A.Fake<IDictionaryTableViewModelHelper>();
            _logger = A.Fake<ILogger>();
            _dictionaryTableViewModel = new DictionaryTableViewModel(
                _dictionaryTableView, _dictionaryTableViewModelHelper, _logger);
        }

        [Test]
        public void Update_ConvertsDictionary_SetsBinding()
        {
            //Arrange
            var dictionaryTable = new DictionaryTable();
            var dataTable = new DataTable();
            A.CallTo(() => _dictionaryTableViewModelHelper.ConvertDictionaryTableToDataTable(dictionaryTable))
                .Returns(dataTable);

            //Act
            _dictionaryTableViewModel.Update(dictionaryTable);

            //Assert
            _dictionaryTableViewModel.DataGridBinding.Should().Be(dataTable);
        }

        [Test]
        public void DataGridBinding_RowChanged_RaisesTableUpdatedFromHelper()
        {
            //Arrange
            var dictionaryTable = new DictionaryTable();
            var dataTable = new DataTable();
            dataTable.Columns.Add("column");
            _dictionaryTableViewModel.DataGridBinding = dataTable;
            _dictionaryTableViewModel.MonitorEvents();

            A.CallTo(() => _dictionaryTableViewModelHelper.ConvertDataTableToDictionaryTable(dataTable))
                .Returns(dictionaryTable);

            //Act
            dataTable.Rows.Add("object");

            //Assert
            _dictionaryTableViewModel.ShouldRaise("DictionaryTableUpdated")
                .WithSender(_dictionaryTableViewModel)
                .WithArgs<DictionaryTableUpdatedArgs>(args => args.DictionaryTable == dictionaryTable);
        }

        [Test]
        public void DataGridBinding_RowChangedTwice_RemovesOldEventListening()
        {
            //Arrange
            var dataTable1 = new DataTable();
            dataTable1.Columns.Add("column");
            _dictionaryTableViewModel.DataGridBinding = dataTable1;
            var dataTable2 = new DataTable();
            _dictionaryTableViewModel.DataGridBinding = dataTable2;
            _dictionaryTableViewModel.MonitorEvents();

            //Act
            dataTable1.Rows.Add("object");

            //Assert
            _dictionaryTableViewModel.ShouldNotRaise("DictionaryTableUpdated");
        }
    }
}
