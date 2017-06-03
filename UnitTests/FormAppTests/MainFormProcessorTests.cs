using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API;
using DnDCharacterSheet;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.FormAppTests
{
    [TestFixture]
    class MainFormProcessorTests
    {
        private MainFormProcessor _mainFormProcessor;
        private ITableLayoutWrapper _tableLayoutWrapper;
        private ICentralLayoutBuilder _centralLayoutBuilder;
        private ITableLayoutWrapper _createdTableLayoutWrapper;
        private IDataEntryFormBuilder _dataEntryFormBuilder;

        [SetUp]
        public void Setup()
        {
            _tableLayoutWrapper = A.Fake<ITableLayoutWrapper>();
            _createdTableLayoutWrapper = A.Fake<ITableLayoutWrapper>();
            _centralLayoutBuilder = A.Fake<ICentralLayoutBuilder>();
            _dataEntryFormBuilder = A.Fake<IDataEntryFormBuilder>();
            _mainFormProcessor = new MainFormProcessor(_tableLayoutWrapper, _centralLayoutBuilder, _dataEntryFormBuilder);
        }

        [Test]
        public void SetUpStatPage_CorrectCalls()
        {
            A.CallTo(() => _centralLayoutBuilder.Create()).Returns(_createdTableLayoutWrapper);

            _mainFormProcessor.SetUpStatPage();
            
            //A.CallTo(() => _createdTableLayoutWrapper.TrueControl).MustHaveHappened();
            A.CallTo(() => _tableLayoutWrapper.Controls.Add(A<IControl>.Ignored, 0, 1)).MustHaveHappened();
        }
    }
}
