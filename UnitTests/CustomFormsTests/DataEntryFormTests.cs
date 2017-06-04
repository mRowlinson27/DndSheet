using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms;
using CustomForms.API;
using CustomForms.API.TableLayoutWrapper;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests.CustomFormsTests
{
    [TestFixture]
    class DataEntryFormTests
    {
        private DataEntryForm _dataEntryForm;
        private ITableLayoutWrapper _tableLayoutWrapper;
        private ITableLayoutColumnStyleCollectionWrapper _layoutColumnStyleCollectionWrapper;
        private ITableLayoutRowStyleCollectionWrapper _layoutRowStyleCollectionWrapper;
        private ITableLayoutControlCollectionWrapper _layoutControlCollectionWrapper;

        [SetUp]
        public void Setup()
        {
            _tableLayoutWrapper = A.Fake<ITableLayoutWrapper>();
            _layoutColumnStyleCollectionWrapper = A.Fake<ITableLayoutColumnStyleCollectionWrapper>();
            _layoutRowStyleCollectionWrapper = A.Fake<ITableLayoutRowStyleCollectionWrapper>();
            _layoutControlCollectionWrapper = A.Fake<ITableLayoutControlCollectionWrapper>();
            _dataEntryForm = new DataEntryForm(_tableLayoutWrapper);
        }

        [Test]
        public void AddCol_SingleColumnAdded()
        {
            A.CallTo(() => _tableLayoutWrapper.AccessColumnStyles).Returns(_layoutColumnStyleCollectionWrapper);

            _dataEntryForm.AddCol();

            A.CallTo(() => _layoutColumnStyleCollectionWrapper.Add(
                A<ColumnStyle>.That.Matches(x => x.SizeType == SizeType.AutoSize))).MustHaveHappened();
        }

        [Test]
        public void AddCols_MultiColumnsAdded()
        {
            A.CallTo(() => _tableLayoutWrapper.AccessColumnStyles).Returns(_layoutColumnStyleCollectionWrapper);

            _dataEntryForm.AddCols(3);

            A.CallTo(() => _layoutColumnStyleCollectionWrapper.Add(
                A<ColumnStyle>.That.Matches(x => x.SizeType == SizeType.AutoSize))).MustHaveHappened(Repeated.Exactly.Times(3));
        }

        [Test]
        public void AddRow_SingleRowAdded()
        {
            A.CallTo(() => _tableLayoutWrapper.AccessRowStyles).Returns(_layoutRowStyleCollectionWrapper);

            _dataEntryForm.AddRow();

            A.CallTo(() => _layoutRowStyleCollectionWrapper.Add(
                A<RowStyle>.That.Matches(x => x.SizeType == SizeType.Absolute && Math.Abs(x.Height - 22) < 0.1))).MustHaveHappened();
        }
        [Test]
        public void AddRows_MultiRowsAdded()
        {
            A.CallTo(() => _tableLayoutWrapper.AccessRowStyles).Returns(_layoutRowStyleCollectionWrapper);

            _dataEntryForm.AddRows(3);

            A.CallTo(() => _layoutRowStyleCollectionWrapper.Add(
                    A<RowStyle>.That.Matches(x => x.SizeType == SizeType.Absolute && Math.Abs(x.Height - 22) < 0.1)))
                .MustHaveHappened(Repeated.Exactly.Times(3));
        }

        [Test]
        public void InsertControl_InsertedWithoutRows_ThrowsException()
        {
            var control = A.Fake<IControl>();
            A.CallTo(() => _tableLayoutWrapper.AccessControls).Returns(_layoutControlCollectionWrapper);

            Assert.That(() => _dataEntryForm.InsertControl(control, 2, 2), Throws.TypeOf(typeof(IndexOutOfRangeException)));
        }

        [Test]
        public void InsertControl_InsertedWithRows_Passes()
        {
            var control = A.Fake<IControl>();
            A.CallTo(() => _tableLayoutWrapper.AccessControls).Returns(_layoutControlCollectionWrapper);

            _dataEntryForm.AddRows(2);
            _dataEntryForm.AddCols(2);
            _dataEntryForm.InsertControl(control, 2, 2);

            A.CallTo(() => _layoutControlCollectionWrapper.Add(control, 2, 2)).MustHaveHappened();
        }

        [Test]
        public void GetControl_NotValid_ThrowsException()
        {
            Assert.That(() => _dataEntryForm.GetControl(2, 2), Throws.TypeOf(typeof(IndexOutOfRangeException)));
        }

        [Test]
        public void GetControl_Valid_ReturnsCorrect()
        {
            var control = A.Fake<IControl>();
            A.CallTo(() => _tableLayoutWrapper.AccessControls).Returns(_layoutControlCollectionWrapper);
            _dataEntryForm.AddRows(2);
            _dataEntryForm.AddCols(2);
            _dataEntryForm.InsertControl(control, 2, 2);

            var value = _dataEntryForm.GetControl(2, 2);

            value.Should().Be(control);
        }
    }
}
