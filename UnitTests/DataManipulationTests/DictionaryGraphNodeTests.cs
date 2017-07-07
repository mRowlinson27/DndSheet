using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DataManipulation;
using FluentAssertions;
using NUnit.Framework;
using SqlDatabase.API.DTO;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    public class DictionaryGraphNodeTests
    {
        [Test]
        public void CreateNew_ReturnsCorrectEid()
        {
            var tableEntity = new TableEntity() { Eid = 0 };

            var dictionaryGraphNode = new DictionaryGraphNode<TableEntity>(tableEntity.Eid, tableEntity);

            dictionaryGraphNode.Eid.Should().Be(tableEntity.Eid);
        }

        [Test]
        public void CreateNew_ContainsOwnEid()
        {
            var tableEntity = new TableEntity() { Eid = 0 };

            var dictionaryGraphNode = new DictionaryGraphNode<TableEntity>(tableEntity.Eid, tableEntity);

            dictionaryGraphNode.ContainsKey(tableEntity.Eid).Should().BeTrue();
        }

        [Test]
        public void CreateNew_GetItselfReturnsCorrectly()
        {
            var tableEntity = new TableEntity() { Eid = 0 };
            var dictionaryGraphNode = new DictionaryGraphNode<TableEntity>(tableEntity.Eid, tableEntity);

            var response = dictionaryGraphNode.Get(tableEntity.Eid);

            response.Should().Be(tableEntity);
        }

        [Test]
        public void AddNew_ContainsNewEid()
        {
            var tableEntity = new TableEntity() { Eid = 0 };
            var tableEntity2 = new TableEntity() { Eid = 1 };
            var dictionaryGraphNode = new DictionaryGraphNode<TableEntity>(tableEntity.Eid, tableEntity);
            var dictionaryGraphNode2 = new DictionaryGraphNode<TableEntity>(tableEntity2.Eid, tableEntity2);

            dictionaryGraphNode.Add(dictionaryGraphNode2);

            dictionaryGraphNode.ContainsKey(tableEntity2.Eid).Should().BeTrue();
        }

        [Test]
        public void Get_FindsChild()
        {
            var tableEntity = new TableEntity() { Eid = 0 };
            var tableEntity2 = new TableEntity() { Eid = 1 };
            var dictionaryGraphNode = new DictionaryGraphNode<TableEntity>(tableEntity.Eid, tableEntity);
            var dictionaryGraphNode2 = new DictionaryGraphNode<TableEntity>(tableEntity2.Eid, tableEntity2);

            dictionaryGraphNode.Add(dictionaryGraphNode2);

            dictionaryGraphNode.Get(tableEntity2.Eid).Should().Be(tableEntity2);
        }

        [Test]
        public void Get_FindsSecondDepthChild()
        {
            var tableEntity = new TableEntity() { Eid = 0 };
            var tableEntity2 = new TableEntity() { Eid = 1 };
            var tableEntity3 = new TableEntity() { Eid = 2 };

            var dictionaryGraphNode3 = new DictionaryGraphNode<TableEntity>(tableEntity3.Eid, tableEntity3);
            var dictionaryGraphNode2 = new DictionaryGraphNode<TableEntity>(tableEntity2.Eid, tableEntity2);
            var dictionaryGraphNode = new DictionaryGraphNode<TableEntity>(tableEntity.Eid, tableEntity);

            dictionaryGraphNode2.Add(dictionaryGraphNode3);
            dictionaryGraphNode.Add(dictionaryGraphNode2);

            dictionaryGraphNode.Get(tableEntity3.Eid).Should().Be(tableEntity3);
        }

        [Test]
        public void Add_CannotAddItself()
        {
            var tableEntity = new TableEntity() { Eid = 0 };

            var dictionaryGraphNode = new DictionaryGraphNode<TableEntity>(tableEntity.Eid, tableEntity);

            Assert.That(() => dictionaryGraphNode.Add(dictionaryGraphNode),
                Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Add_ChildHasCorrectParent()
        {
            var tableEntity = new TableEntity() { Eid = 0 };
            var tableEntity2 = new TableEntity() { Eid = 1 };
            var dictionaryGraphNode = new DictionaryGraphNode<TableEntity>(tableEntity.Eid, tableEntity);
            var dictionaryGraphNode2 = new DictionaryGraphNode<TableEntity>(tableEntity2.Eid, tableEntity2);

            dictionaryGraphNode.Add(dictionaryGraphNode2);

            dictionaryGraphNode2.Parent.Should().Be(dictionaryGraphNode);
        }

        [Test]
        public void Head_HasNoParent()
        {
            var tableEntity = new TableEntity() { Eid = 0 };
            var dictionaryGraphNode = new DictionaryGraphNode<TableEntity>(tableEntity.Eid, tableEntity);

            dictionaryGraphNode.Parent.Should().BeNull();
        }

        [Test]
        public void Remove_RemovesChild()
        {
            var tableEntity = new TableEntity() { Eid = 0 };
            var tableEntity2 = new TableEntity() { Eid = 1 };
            var dictionaryGraphNode = new DictionaryGraphNode<TableEntity>(tableEntity.Eid, tableEntity);
            var dictionaryGraphNode2 = new DictionaryGraphNode<TableEntity>(tableEntity2.Eid, tableEntity2);
            dictionaryGraphNode.Add(dictionaryGraphNode2);

            dictionaryGraphNode.Remove(dictionaryGraphNode2);

            dictionaryGraphNode.Contains(dictionaryGraphNode2).Should().BeFalse();
        }

        [Test]
        public void Remove_NoEntity_FalseReturned()
        {
            var tableEntity = new TableEntity() { Eid = 0 };
            var tableEntity2 = new TableEntity() { Eid = 1 };
            var dictionaryGraphNode = new DictionaryGraphNode<TableEntity>(tableEntity.Eid, tableEntity);
            var dictionaryGraphNode2 = new DictionaryGraphNode<TableEntity>(tableEntity2.Eid, tableEntity2);
            dictionaryGraphNode.Add(dictionaryGraphNode2);

            var response = dictionaryGraphNode.Remove(3);

            response.Should().BeFalse();
        }

        [Test]
        public void Remove_RemovesSecondDepthChild()
        {
            var tableEntity = new TableEntity() { Eid = 0 };
            var tableEntity2 = new TableEntity() { Eid = 1 };
            var tableEntity3 = new TableEntity() { Eid = 2 };

            var dictionaryGraphNode3 = new DictionaryGraphNode<TableEntity>(tableEntity3.Eid, tableEntity3);
            var dictionaryGraphNode2 = new DictionaryGraphNode<TableEntity>(tableEntity2.Eid, tableEntity2);
            var dictionaryGraphNode = new DictionaryGraphNode<TableEntity>(tableEntity.Eid, tableEntity);

            dictionaryGraphNode2.Add(dictionaryGraphNode3);
            dictionaryGraphNode.Add(dictionaryGraphNode2);

            dictionaryGraphNode.Remove(dictionaryGraphNode3);

            dictionaryGraphNode.Contains(dictionaryGraphNode3).Should().BeFalse();
        }

        [Test]
        public void Remove_SetsChildParentToNull()
        {
            var tableEntity = new TableEntity() { Eid = 0 };
            var tableEntity2 = new TableEntity() { Eid = 1 };
            var dictionaryGraphNode = new DictionaryGraphNode<TableEntity>(tableEntity.Eid, tableEntity);
            var dictionaryGraphNode2 = new DictionaryGraphNode<TableEntity>(tableEntity2.Eid, tableEntity2);
            dictionaryGraphNode.Add(dictionaryGraphNode2);

            dictionaryGraphNode.Remove(dictionaryGraphNode2);

            dictionaryGraphNode2.Parent.Should().BeNull();
        }
    }
}
