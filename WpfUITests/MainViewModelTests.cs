
namespace WpfUI.UnitTests
{
    using API;
    using API.Dtos;
    using FakeItEasy;
    using NUnit.Framework;
    using Utilities.API;
    using ViewModels;

    [TestFixture]
    public class MainViewModelTests
    {
        private MainViewModel _mainViewModel;
        private IMainWindow _mainWindow;
        private IDictionaryTableFactory _dictionaryTableFactory;
        private ILogger _logger;
        private IDictionaryTableView _dictionaryTableView;

        [SetUp]
        public void Setup()
        {
            _mainWindow = A.Fake<IMainWindow>();
            _dictionaryTableFactory = A.Fake<IDictionaryTableFactory>();
            _logger = A.Fake<ILogger>();
            _mainViewModel = new MainViewModel(_mainWindow)
            {
                DictionaryTableFactory = _dictionaryTableFactory,
                Logger = _logger,
            };

            _dictionaryTableView = A.Fake<IDictionaryTableView>();
        }

        [Test]
        public void Initialize_CreatesDictionaryTableView_AndUpdatesIt()
        {
            //Arrange
            A.CallTo(() => _dictionaryTableFactory.Create()).Returns(_dictionaryTableView);

            //Act
            _mainViewModel.Initialize();

            //Assert
            A.CallTo(() => _dictionaryTableView.Update(A<DictionaryTable>.Ignored)).MustHaveHappened();
        }
    }
}
