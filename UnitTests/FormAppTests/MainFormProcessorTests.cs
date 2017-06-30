using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomFormManipulation.API;
using CustomForms.API;
using CustomForms.API.DTOs;
using CustomForms.API.TableLayoutWrapper;
using CustomFormStructures.API;
using CustomFormStructures.API.Builders;
using DataManipulation.API;
using DnDCharacterSheet;
using FakeItEasy;
using FormApp;
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
        private IDataEntryFormManager _dataEntryFormManager;
        private IVerticalScrollStrategy _VerticalScrollStrategy;

        [SetUp]
        public void Setup()
        {
            _tableLayoutWrapper = A.Fake<ITableLayoutWrapper>();
            _createdTableLayoutWrapper = A.Fake<ITableLayoutWrapper>();
            _centralLayoutBuilder = A.Fake<ICentralLayoutBuilder>();
            _dataEntryFormManager = A.Fake<IDataEntryFormManager>();
            _VerticalScrollStrategy = A.Fake<IVerticalScrollStrategy>();
            _mainFormProcessor = new MainFormProcessor(_tableLayoutWrapper, _centralLayoutBuilder, _dataEntryFormManager,
                _VerticalScrollStrategy);
        }

        [Test]
        public void SetUpStatPage_CorrectCalls()
        {
            A.CallTo(() => _centralLayoutBuilder.Build(A<IControlPropertiesStyle>.Ignored)).Returns(_createdTableLayoutWrapper);

            _mainFormProcessor.SetUpStatPage();
            
            A.CallTo(() => _tableLayoutWrapper.AccessControls.Add(A<IControl>.Ignored, 2, 1)).MustHaveHappened();
        }
    }
}
