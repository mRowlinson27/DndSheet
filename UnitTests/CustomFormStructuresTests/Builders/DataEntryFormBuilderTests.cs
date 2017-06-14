using System.Collections.Generic;
using CustomForms;
using CustomForms.API;
using CustomForms.API.Factories;
using CustomFormStructures.API;
using CustomFormStructures.Builders;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.CustomFormStructuresTests.Builders
{
    [TestFixture]
    class DataEntryFormBuilderTests
    {
        private DataEntryFormBuilder _builder;
        private IDataEntryForm _dataEntryForm;
        private ITableLayoutWrapperFactory _tableLayoutWrapperFactory;

        [SetUp]
        public void Setup()
        {
            _dataEntryForm = A.Fake<IDataEntryForm>();
            _tableLayoutWrapperFactory = A.Fake<ITableLayoutWrapperFactory>();
            _builder = new DataEntryFormBuilder(_tableLayoutWrapperFactory);
        }

        [Test]
        public void Apply_CorrectRowsAdded()
        {
            var data = new List<List<ITrueControl>>
            {
                new List<ITrueControl>
                {
                    new LabelWrapper() {Text = "a"},
                    new LabelWrapper() {Text = "b"}
                },
                new List<ITrueControl>
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
            var data = new List<List<ITrueControl>>
            {
                new List<ITrueControl>
                {
                    new LabelWrapper() {Text = "a"},
                    new LabelWrapper() {Text = "b"}
                },
                new List<ITrueControl>
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
            var data = new List<List<ITrueControl>>
            {
                new List<ITrueControl>
                {
                    new LabelWrapper() {Text = "a"},
                    new LabelWrapper() {Text = "b"}
                },
                new List<ITrueControl>
                {
                    new LabelWrapper() {Text = "1"},
                    new LabelWrapper() {Text = "2"},
                    new LabelWrapper() {Text = "3"}
                }
            };

            _builder.Apply(_dataEntryForm, data);

            A.CallTo(() => _dataEntryForm.InsertControl(A<ITrueControl>.That.Matches(x => (x as ILabelWrapper).Text == "a"),
                1, 1)).MustHaveHappened();
            A.CallTo(() => _dataEntryForm.InsertControl(A<ITrueControl>.That.Matches(x => (x as ILabelWrapper).Text == "b"),
                1, 2)).MustHaveHappened();
            A.CallTo(() => _dataEntryForm.InsertControl(A<ITrueControl>.That.Matches(x => (x as ILabelWrapper).Text == "1"),
                2, 1)).MustHaveHappened();
            A.CallTo(() => _dataEntryForm.InsertControl(A<ITrueControl>.That.Matches(x => (x as ILabelWrapper).Text == "2"),
                2, 2)).MustHaveHappened();
            A.CallTo(() => _dataEntryForm.InsertControl(A<ITrueControl>.That.Matches(x => (x as ILabelWrapper).Text == "3"),
                2, 3)).MustHaveHappened();
        }
    }
}
