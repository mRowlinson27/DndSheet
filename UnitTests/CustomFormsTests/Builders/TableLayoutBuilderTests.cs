using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomForms;
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
        private IDataEntryForm _dataEntryForm;

        [SetUp]
        public void Setup()
        {
            _dataEntryForm = A.Fake<IDataEntryForm>();
            _builder = new TableLayoutBuilder();
        }

        [Test]
        public void Apply_CorrectRowsAdded()
        {
            var data = new List<List<IControl>>
            {
                new List<IControl>
                {
                    new LabelWrapper() {Text = "a"},
                    new LabelWrapper() {Text = "b"}
                },
                new List<IControl>
                {
                    new LabelWrapper() {Text = "1"},
                    new LabelWrapper() {Text = "2"},
                    new LabelWrapper() {Text = "3"}
                }
            };

            _builder.Apply(_dataEntryForm, data);

            A.CallTo(() => _dataEntryForm.AddRows(2)).MustHaveHappened();
        }

        [Test]
        public void Apply_CorrectColsAdded()
        {
            var data = new List<List<IControl>>
            {
                new List<IControl>
                {
                    new LabelWrapper() {Text = "a"},
                    new LabelWrapper() {Text = "b"}
                },
                new List<IControl>
                {
                    new LabelWrapper() {Text = "1"},
                    new LabelWrapper() {Text = "2"},
                    new LabelWrapper() {Text = "3"}
                }
            };

            _builder.Apply(_dataEntryForm, data);

            A.CallTo(() => _dataEntryForm.AddCols(3)).MustHaveHappened();
        }

        [Test]
        public void Apply_CorrectInserts()
        {
            var data = new List<List<IControl>>
            {
                new List<IControl>
                {
                    new LabelWrapper() {Text = "a"},
                    new LabelWrapper() {Text = "b"}
                },
                new List<IControl>
                {
                    new LabelWrapper() {Text = "1"},
                    new LabelWrapper() {Text = "2"},
                    new LabelWrapper() {Text = "3"}
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
