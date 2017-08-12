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
    public class DirectedGraphTests
    {
        private DirectedGraph<string, int> _directedGraph;

        [SetUp]
        public void Setup()
        {
            _directedGraph = new DirectedGraph<string, int>();
        }

        [Test]
        public void Add_AddSameObject_ThrowsException()
        {
            var value = "test";

            _directedGraph.Add(value);

            Assert.Throws(typeof(ArgumentException), () =>_directedGraph.Add(value));
        }

        [Test]
        public void AddDirectedEdge_WithoutFromObject_ThrowsException()
        {
            var toValue = "to";
            var fromValue = "from";

            _directedGraph.Add(toValue);

            Assert.Throws(typeof(KeyNotFoundException), () => _directedGraph.AddDirectedEdge(fromValue, toValue, 0));
        }

        [Test]
        public void AddDirectedEdge_WithoutToObject_ThrowsException()
        {
            var toValue = "to";
            var fromValue = "from";

            _directedGraph.Add(fromValue);

            Assert.Throws(typeof(KeyNotFoundException), () => _directedGraph.AddDirectedEdge(fromValue, toValue, 0));
        }

        [Test]
        public void AddDirectedEdge_SameTripleTwice_ThrowsException()
        {
            var toValue = "to";
            var fromValue = "from";
            _directedGraph.Add(toValue);
            _directedGraph.Add(fromValue);

            _directedGraph.AddDirectedEdge(fromValue, toValue, 0);
            Assert.Throws(typeof(ArgumentException), () => _directedGraph.AddDirectedEdge(fromValue, toValue, 0));
        }

        [Test]
        public void AddDirectedEdge_SameToAndFrom_DifferentCost_Valid()
        {
            var toValue = "to";
            var fromValue = "from";
            _directedGraph.Add(toValue);
            _directedGraph.Add(fromValue);

            _directedGraph.AddDirectedEdge(fromValue, toValue, 0);
            _directedGraph.AddDirectedEdge(fromValue, toValue, 1);
        }

        [Test]
        public void RemoveDirectedEdge_NoEdge_ThrowsException()
        {
            var toValue = "to";
            var fromValue = "from";
            _directedGraph.Add(toValue);
            _directedGraph.Add(fromValue);

            Assert.Throws(typeof(KeyNotFoundException), () =>_directedGraph.RemoveDirectedEdge(fromValue, toValue, 0));
        }

        [Test]
        public void RemoveDirectedEdge_EliminatesParentEdgesReleventToIt()
        {
            var toValue = "to";
            var fromValue = "from";
            _directedGraph.Add(toValue);
            _directedGraph.Add(fromValue);

            _directedGraph.AddDirectedEdge(fromValue, toValue, 0);
            _directedGraph.RemoveDirectedEdge(fromValue, toValue, 0);

            var parents = _directedGraph.GetParentRelationOf(toValue);

            parents.Should().BeNullOrEmpty();
        }

        [Test]
        public void RemoveDirectedEdge_EliminatesChildEdgesReleventToIt()
        {
            var toValue = "to";
            var fromValue = "from";
            _directedGraph.Add(toValue);
            _directedGraph.Add(fromValue);

            _directedGraph.AddDirectedEdge(fromValue, toValue, 0);
            _directedGraph.RemoveDirectedEdge(fromValue, toValue, 0);

            var children = _directedGraph.GetChildRelationOf(fromValue);

            children.Should().BeNullOrEmpty();
        }

        [Test]
        public void GetParentRelationOf_ReturnsCorrectly()
        {
            var toValue = "to";
            var fromValue = "from";
            var cost = 0;
            _directedGraph.Add(toValue);
            _directedGraph.Add(fromValue);

            _directedGraph.AddDirectedEdge(fromValue, toValue, cost);

            var parents = _directedGraph.GetParentRelationOf(toValue);

            parents.Should().BeEquivalentTo(new List<Tuple<string, int>> { new Tuple<string, int>(fromValue, cost) } );
        }

        [Test]
        public void GetParentRelationOf_NoParents_ReturnsCorrectly()
        {
            var fromValue = "from";
            _directedGraph.Add(fromValue);

            var parents = _directedGraph.GetChildRelationOf(fromValue);

            parents.Should().BeNullOrEmpty();
        }

        [Test]
        public void GetChildRelationOf_ReturnsCorrectly()
        {
            var toValue = "to";
            var fromValue = "from";
            var cost = 0;
            _directedGraph.Add(toValue);
            _directedGraph.Add(fromValue);

            _directedGraph.AddDirectedEdge(fromValue, toValue, cost);

            var children = _directedGraph.GetChildRelationOf(fromValue);

            children.Should().BeEquivalentTo(new List<Tuple<string, int>> { new Tuple<string, int>(toValue, cost) });
        }

        [Test]
        public void GetChildRelationOf_NoChildren_ReturnsCorrectly()
        {
            var fromValue = "from";
            _directedGraph.Add(fromValue);

            var children = _directedGraph.GetChildRelationOf(fromValue);

            children.Should().BeNullOrEmpty();
        }

        [Test]
        public void Remove_NoNode_ThrowsException()
        {
            var toValue = "to";

            Assert.Throws(typeof(KeyNotFoundException), () =>_directedGraph.Remove(toValue));
        }

        [Test]
        public void Remove_EliminatesChildEdgesReleventToIt()
        {
            var toValue = "to";
            var fromValue = "from";
            _directedGraph.Add(toValue);
            _directedGraph.Add(fromValue);

            _directedGraph.AddDirectedEdge(fromValue, toValue, 0);
            _directedGraph.Remove(toValue);

            var children = _directedGraph.GetChildRelationOf(fromValue);

            children.Should().BeNullOrEmpty();
        }

        [Test]
        public void Remove_EliminatesParentEdgesReleventToIt()
        {
            var toValue = "to";
            var fromValue = "from";
            _directedGraph.Add(toValue);
            _directedGraph.Add(fromValue);

            _directedGraph.AddDirectedEdge(fromValue, toValue, 0);
            _directedGraph.Remove(fromValue);

            var parents = _directedGraph.GetParentRelationOf(toValue);

            parents.Should().BeNullOrEmpty();
        }

        [Test]
        public void Clear_RemovesAllPoints()
        {
            var toValue = "to";
            var fromValue = "from";
            _directedGraph.Add(toValue);
            _directedGraph.Add(fromValue);

            _directedGraph.Clear();

            _directedGraph.Count.Should().Be(0);
        }
    }
}
