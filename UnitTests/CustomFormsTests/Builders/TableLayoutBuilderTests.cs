using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms.API;
using CustomForms.API.Factories;
using CustomForms.Builders;
using CustomForms.Factories;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.CustomFormsTests.Builders
{
    [TestFixture]
    class TableLayoutBuilderTests
    {
        private TableLayoutBuilder _builder;
        private ILabelWrapperFactory _labelWrapperFactory;
        private IDataEntryForm _dataEntryForm;

        [SetUp]
        public void Setup()
        {
            _dataEntryForm = A.Fake<IDataEntryForm>();
            _labelWrapperFactory = new LabelWrapperFactory();
            _builder = new TableLayoutBuilder(_labelWrapperFactory);
        }

        [Test]
        public void Apply_CorrectRowsAdded()
        {
            List<List<string>> data = new List<List<string>>
            {
                new List<string>
                {
                    "a", "b"
                },
                new List<string>
                {
                    "a", "b", "c"
                }
            };

            _builder.Apply(_dataEntryForm, data);

            A.CallTo(() => _dataEntryForm.AddRows(2)).MustHaveHappened();
        }

        [Test]
        public void Apply_CorrectColsAdded()
        {
            List<List<string>> data = new List<List<string>>
            {
                new List<string>
                {
                    "a", "b"
                },
                new List<string>
                {
                    "a", "b", "c"
                }
            };

            _builder.Apply(_dataEntryForm, data);

            A.CallTo(() => _dataEntryForm.AddCols(3)).MustHaveHappened();
        }

        [Test]
        public void Apply_CorrectInserts()
        {
            List<List<string>> data = new List<List<string>>
            {
                new List<string>
                {
                    "a", "b"
                },
                new List<string>
                {
                    "1", "2", "3"
                }
            };

            _builder.Apply(_dataEntryForm, data);

            A.CallTo(() => _dataEntryForm.InsertControl(A<IControl>.That.Matches(x => (x as ILabelWrapper).Text == "a"),
                1, 1)).MustHaveHappened();
            A.CallTo(() => _dataEntryForm.InsertControl(A<IControl>.That.Matches(x => (x as ILabelWrapper).Text == "b"),
                1, 2)).MustHaveHappened();
            A.CallTo(() => _dataEntryForm.InsertControl(A<IControl>.That.Matches(x => (x as ILabelWrapper).Text == "1"),
                2, 1)).MustHaveHappened();
            A.CallTo(() => _dataEntryForm.InsertControl(A<IControl>.That.Matches(x => (x as ILabelWrapper).Text == "2"),
                2, 2)).MustHaveHappened();
            A.CallTo(() => _dataEntryForm.InsertControl(A<IControl>.That.Matches(x => (x as ILabelWrapper).Text == "3"),
                2, 3)).MustHaveHappened();
        }
    }
}
