using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Utilities.Implementation;

namespace UnitTests.Utilities
{
    [TestFixture]
    public class MostlyFullSequenceTests
    {
        private MostlyFullSequence _mostlyFullSequence;

        [SetUp]
        public void Setup()
        {
            _mostlyFullSequence = new MostlyFullSequence();
        }

        [Test]
        public void Insert_OneInserted_CorrectUnderlyingList()
        {
            var numToBeInserted = 1;
            var correctList = new List<int>
            {
                0, 1
            };

            _mostlyFullSequence.Insert(numToBeInserted);

            var list = _mostlyFullSequence.GetInternaList();

            list.ShouldBeEquivalentTo(correctList);
        }

        [Test]
        public void Insert_TwoInserted_CorrectUnderlyingList()
        {
            var numToBeInserted = 2;
            var correctList = new List<int>
            {
                0, 0, 2, 2
            };

            _mostlyFullSequence.Insert(numToBeInserted);

            var list = _mostlyFullSequence.GetInternaList();

            list.ShouldBeEquivalentTo(correctList);
        }

        [Test]
        public void Insert_TwoThenOneInserted_CorrectUnderlyingList()
        {
            var numsToBeInserted = new List<int> { 2, 1};
            var correctList = new List<int>
            {
                0, 2
            };

            foreach (var n in numsToBeInserted)
            {
                _mostlyFullSequence.Insert(n);
            }
            var list = _mostlyFullSequence.GetInternaList();

            list.ShouldBeEquivalentTo(correctList);
        }

        [Test]
        public void Insert_TenThenFiveInserted_CorrectUnderlyingList()
        {
            var numsToBeInserted = new List<int> { 10, 5 };
            var correctList = new List<int>
            {
                0, 0, 5, 5, 10, 10
            };

            foreach (var n in numsToBeInserted)
            {
                _mostlyFullSequence.Insert(n);
            }

            var list = _mostlyFullSequence.GetInternaList();

            list.ShouldBeEquivalentTo(correctList);
        }

        [Test]
        public void InsertMultiple_TenThenFiveInserted_CorrectUnderlyingList()
        {
            var numsToBeInserted = new List<int> { 10, 5 };
            var correctList = new List<int>
            {
                0, 0, 5, 5, 10, 10
            };

            _mostlyFullSequence.InsertMultiple(numsToBeInserted);

            var list = _mostlyFullSequence.GetInternaList();

            list.ShouldBeEquivalentTo(correctList);
        }

        [Test]
        public void Insert_TenThenOneInserted_CorrectUnderlyingList()
        {
            var numsToBeInserted = new List<int> { 10, 1 };
            var correctList = new List<int>
            {
                0, 1, 10, 10
            };

            foreach (var n in numsToBeInserted)
            {
                _mostlyFullSequence.Insert(n);
            }

            var list = _mostlyFullSequence.GetInternaList();

            list.ShouldBeEquivalentTo(correctList);
        }

        [Test]
        public void Insert_TenThenNineInserted_CorrectUnderlyingList()
        {
            var numsToBeInserted = new List<int> { 10, 9 };
            var correctList = new List<int>
            {
                0, 0, 9, 10
            };

            foreach (var n in numsToBeInserted)
            {
                _mostlyFullSequence.Insert(n);
            }

            var list = _mostlyFullSequence.GetInternaList();

            list.ShouldBeEquivalentTo(correctList);
        }

        [Test]
        public void Insert_OneTwice_ExceptionOccurs()
        {
            var numsToBeInserted = new List<int> {1, 1};

            _mostlyFullSequence.Insert(numsToBeInserted[0]);

            Assert.That(() => _mostlyFullSequence.Insert(numsToBeInserted[1]),
                Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Insert_OneToTenThenFiveAgain_ExceptionOccurs()
        {
            var numsToBeInserted = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 5};

            Assert.That(() => _mostlyFullSequence.InsertMultiple(numsToBeInserted),
                Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Delete_NoValues_ExceptionOccurs()
        {
            Assert.That(() => _mostlyFullSequence.DeleteAt(1),
                Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Delete_Zero_ExceptionOccurs()
        {
            Assert.That(() => _mostlyFullSequence.DeleteAt(0),
                Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Add_OneInserted_NextIsTwo()
        {
            var numToBeInserted = 1;
            var next = 2;

            _mostlyFullSequence.Insert(numToBeInserted);

            _mostlyFullSequence.Add().Should().Be(next);
        }

        [Test]
        public void Add_OneInserted_NextIsTwo_CorrectUnderlyingList()
        {
            var numToBeInserted = 1;
            var correctList = new List<int>
            {
                0, 2
            };

            _mostlyFullSequence.Insert(numToBeInserted);
            _mostlyFullSequence.Add();

            _mostlyFullSequence.GetInternaList().Should().BeEquivalentTo(correctList);
        }

        [Test]
        public void Add_TwoInserted_NextIsOne()
        {
            var numToBeInserted = 2;
            var next = 1;

            _mostlyFullSequence.Insert(numToBeInserted);

            _mostlyFullSequence.Add().Should().Be(next);
        }

        [Test]
        public void Add_TwoInserted_NextIsOne_CorrectUnderlyingList()
        {
            var numToBeInserted = 2;
            var correctList = new List<int>
            {
                0, 2
            };

            _mostlyFullSequence.Insert(numToBeInserted);
            _mostlyFullSequence.Add();

            _mostlyFullSequence.GetInternaList().Should().BeEquivalentTo(correctList);
        }

        [Test]
        public void Add_FiveInserted_AddedIsSix()
        {
            var numsToBeInserted = new List<int> {1, 2, 3, 4, 5};
            var next = 6;

            _mostlyFullSequence.InsertMultiple(numsToBeInserted);

            _mostlyFullSequence.Add().Should().Be(next);
        }

        [Test]
        public void Add_FiveInserted_AddedIsSix_CorrectUnderlyingList()
        {
            var numsToBeInserted = new List<int> { 1, 2, 3, 4, 5 };
            var correctList = new List<int>
            {
                0, 6
            };

            _mostlyFullSequence.InsertMultiple(numsToBeInserted);
            _mostlyFullSequence.Add();

            _mostlyFullSequence.GetInternaList().Should().BeEquivalentTo(correctList);
        }

        [Test]
        public void Add_OneAndThreeInserted_NextIsTwo()
        {
            var numsToBeInserted = new List<int> { 1, 3 };
            var next = 2;

            _mostlyFullSequence.InsertMultiple(numsToBeInserted);

            _mostlyFullSequence.Add().Should().Be(next);
        }

        [Test]
        public void Add_OneAndThreeInserted_NextIsTwo_CorrectUnderlyingList()
        {
            var numsToBeInserted = new List<int> { 1, 3 };
            var correctList = new List<int>
            {
                0, 3
            };

            _mostlyFullSequence.InsertMultiple(numsToBeInserted);
            _mostlyFullSequence.Add();

            _mostlyFullSequence.GetInternaList().Should().BeEquivalentTo(correctList);
        }

        [Test]
        public void AddMultiple_OneAndThreeInserted_CorrectNextFiveAdditions()
        {
            var numsToBeInserted = new List<int> { 1, 3 };
            var correctAdds = new List<int>
            {
                2, 4, 5, 6, 7
            };

            _mostlyFullSequence.InsertMultiple(numsToBeInserted);

            _mostlyFullSequence.AddMultiple(5).Should().BeEquivalentTo(correctAdds);
        }

        [Test]
        public void DeleteAt_FiveInserted_DeleteFive_CorrectUnderlyingList()
        {
            var numsToBeInserted = new List<int> { 5 };
            var correctList = new List<int>
            {
                0, 0
            };

            _mostlyFullSequence.InsertMultiple(numsToBeInserted);
            _mostlyFullSequence.DeleteAt(5);

            _mostlyFullSequence.GetInternaList().Should().BeEquivalentTo(correctList);
        }

        [Test]
        public void DeleteAt_FiveSixSevenInserted_DeleteFive_CorrectUnderlyingList()
        {
            var numsToBeInserted = new List<int> { 5, 6, 7 };
            var correctList = new List<int>
            {
                0, 0, 6, 7
            };

            _mostlyFullSequence.InsertMultiple(numsToBeInserted);
            _mostlyFullSequence.DeleteAt(5);

            _mostlyFullSequence.GetInternaList().Should().BeEquivalentTo(correctList);
        }

        [Test]
        public void DeleteAt_FiveSixSevenInserted_DeleteSix_CorrectUnderlyingList()
        {
            var numsToBeInserted = new List<int> { 5, 6, 7 };
            var correctList = new List<int>
            {
                0, 0, 5, 5, 7, 7
            };

            _mostlyFullSequence.InsertMultiple(numsToBeInserted);
            _mostlyFullSequence.DeleteAt(6);

            _mostlyFullSequence.GetInternaList().Should().BeEquivalentTo(correctList);
        }

        [Test]
        public void DeleteAt_FiveSixSevenInserted_DeleteSeven_CorrectUnderlyingList()
        {
            var numsToBeInserted = new List<int> { 5, 6, 7 };
            var correctList = new List<int>
            {
                0, 0, 5, 6
            };

            _mostlyFullSequence.InsertMultiple(numsToBeInserted);
            _mostlyFullSequence.DeleteAt(7);

            _mostlyFullSequence.GetInternaList().Should().BeEquivalentTo(correctList);
        }

        [Test]
        public void Clear_FiveSixSevenInsertedThenCleared_CorrectUnderlyingList()
        {
            var numsToBeInserted = new List<int> { 5, 6, 7 };
            var correctList = new List<int>
            {
                0, 0
            };

            _mostlyFullSequence.InsertMultiple(numsToBeInserted);
            _mostlyFullSequence.Clear();

            _mostlyFullSequence.GetInternaList().Should().BeEquivalentTo(correctList);
        }
    }
}
