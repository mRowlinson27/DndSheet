using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation;
using DataManipulation.DTO;
using DataManipulation.Interfaces;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using Utilities.API;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    public class PointGraphTests
    {
        private PointGraph _pointGraph;
        private IDirectedGraph<IPoint, PointEquation> _underlyingDirectedGraph;
        private IPointUpdateSubscriber _pointUpdateSubscriber;

        [SetUp]
        public void Setup()
        {
            _underlyingDirectedGraph = A.Fake<IDirectedGraph<IPoint, PointEquation>>();
            _pointUpdateSubscriber = A.Fake<IPointUpdateSubscriber>();
            _pointGraph = new PointGraph(_underlyingDirectedGraph, _pointUpdateSubscriber);
        }

        [Test]
        public void AddPoint_InsertsIntoUnderlyingGraph()
        {
            var eid = 1;
            var point = A.Fake<IPoint>();
            A.CallTo(() => point.Eid).Returns(eid);

            _pointGraph.AddPoint(point);

            A.CallTo(() => _underlyingDirectedGraph.Add(point)).MustHaveHappened();
        }

        [Test]
        public void AddPoint_PassesPointToSubscriber()
        {
            var eid = 1;
            var point = A.Fake<IPoint>();
            A.CallTo(() => point.Eid).Returns(eid);

            _pointGraph.AddPoint(point);

            A.CallTo(() => _pointUpdateSubscriber.SubscribeToPoint(point)).MustHaveHappened();
        }

        [Test]
        public void AddPoint_InsertSameTwice_ThrowsException()
        {
            var eid = 1;
            var point = A.Fake<IPoint>();
            A.CallTo(() => point.Eid).Returns(eid);

            _pointGraph.AddPoint(point);

            Assert.Throws(typeof(ArgumentException), () => _pointGraph.AddPoint(point));
        }

        [Test]
        public void AddPoint_InsertEquationEid_ThrowsException()
        {
            var eid = 1;
            var point = A.Fake<IPoint>();
            A.CallTo(() => point.Eid).Returns(eid);
            var equation = new PointEquation(eid, "");

            _pointGraph.AddEquation(equation);

            Assert.Throws(typeof(ArgumentException), () => _pointGraph.AddPoint(point));
        }

        [Test]
        public void GetPoint_ValidEid_ReturnsCorrectPoint()
        {
            var eid = 1;
            var point = A.Fake<IPoint>();
            A.CallTo(() => point.Eid).Returns(eid);

            _pointGraph.AddPoint(point);

            _pointGraph.GetPoint(eid).Should().Be(point);
        }

        [Test]
        public void GetPoint_NotValidEid_ReturnsNull()
        {
            _pointGraph.GetPoint(0).Should().BeNull();
        }

        [Test]
        public void GetPoint_EidEquation_ReturnsNull()
        {
            var eid = 1;
            var equation = new PointEquation(eid, null);

            _pointGraph.AddEquation(equation);

            _pointGraph.GetPoint(eid).Should().BeNull();
        }

        [Test]
        public void DeletePoint_DeletesFromUnderlyingGraph()
        {
            var eid = 1;
            var point = A.Fake<IPoint>();
            A.CallTo(() => point.Eid).Returns(eid);
            _pointGraph.AddPoint(point);

            _pointGraph.DeletePoint(point);

            A.CallTo(() => _underlyingDirectedGraph.Remove(point)).MustHaveHappened();
        }

        [Test]
        public void DeletePoint_PassesPointToSubscriber()
        {
            var eid = 1;
            var point = A.Fake<IPoint>();
            A.CallTo(() => point.Eid).Returns(eid);
            _pointGraph.AddPoint(point);

            _pointGraph.DeletePoint(point);

            A.CallTo(() => _pointUpdateSubscriber.UnSubscribeToPoint(point)).MustHaveHappened();
        }

        [Test]
        public void DeletePoint_AllowsReadding()
        {
            var eid = 1;
            var point = A.Fake<IPoint>();
            A.CallTo(() => point.Eid).Returns(eid);

            _pointGraph.AddPoint(point);
            _pointGraph.DeletePoint(point);
            _pointGraph.AddPoint(point);
        }

        [Test]
        public void AddEquation_AddTwice_ThrowsException()
        {
            var eid = 1;
            var equation = new PointEquation(eid, "");

            _pointGraph.AddEquation(equation);

            Assert.Throws(typeof(ArgumentException), () => _pointGraph.AddEquation(equation));
        }

        [Test]
        public void AddEquation_AddPointEid_ThrowsException()
        {
            var eid = 1;
            var equation = new PointEquation(eid, "");
            var point = A.Fake<IPoint>();
            A.CallTo(() => point.Eid).Returns(eid);

            _pointGraph.AddPoint(point);

            Assert.Throws(typeof(ArgumentException), () => _pointGraph.AddEquation(equation));
        }

        [Test]
        public void GetEquation_ValidEid_ReturnsCorrectEquation()
        {
            var eid = 1;
            var equation = new PointEquation(eid, null);

            _pointGraph.AddEquation(equation);

            _pointGraph.GetEquation(eid).Should().Be(equation);
        }

        [Test]
        public void GetEquation_NotValidEid_ReturnsNull()
        {
            _pointGraph.GetEquation(0).Should().BeNull();
        }

        [Test]
        public void GetEquation_EidEquation_ReturnsNull()
        {
            var eid = 1;
            var point = A.Fake<IPoint>();
            A.CallTo(() => point.Eid).Returns(eid);

            _pointGraph.AddPoint(point);

            _pointGraph.GetEquation(eid).Should().BeNull();
        }

        [Test]
        public void GetEquationByValue_ValidString_ReturnsCorrectEquation()
        {
            var eid = 1;
            var equ = "1+1";
            var equation = new PointEquation(eid, equ);

            _pointGraph.AddEquation(equation);

            _pointGraph.GetEquationByValue(equ).Should().Be(equation);
        }

        [Test]
        public void GetEquationByValue_NoMatchingString_ReturnsNull()
        {
            var equ = "1+1";

            _pointGraph.GetEquationByValue(equ).Should().BeNull();
        }

        [Test]
        public void DeleteEquation_AllowsReadding()
        {
            var eid = 1;
            var equation = new PointEquation(eid, "");

            _pointGraph.AddEquation(equation);
            _pointGraph.DeleteEquation(equation);
            _pointGraph.AddEquation(equation);
        }

        [Test]
        public void AddEquationRelationship_FromDoesntExist_ThrowsException()
        {
            int fromEid = 0;
            int toEid = 1;
            int equationEid = 2;
            var fromPoint = A.Fake<IPoint>();
            A.CallTo(() => fromPoint.Eid).Returns(fromEid);
            var toPoint = A.Fake<IPoint>();
            A.CallTo(() => fromPoint.Eid).Returns(toEid);
            var equation = new PointEquation(equationEid, null);

            _pointGraph.AddPoint(toPoint);
            _pointGraph.AddEquation(equation);

            Assert.Throws(typeof(KeyNotFoundException), () => _pointGraph.AddEquationRelationship(fromPoint, toPoint, equation));
        }

        [Test]
        public void AddEquationRelationship_EquationDoesntExist_ThrowsException()
        {
            int fromEid = 0;
            int toEid = 1;
            int equationEid = 2;
            var fromPoint = A.Fake<IPoint>();
            A.CallTo(() => fromPoint.Eid).Returns(fromEid);
            var toPoint = A.Fake<IPoint>();
            A.CallTo(() => fromPoint.Eid).Returns(toEid);
            var equation = new PointEquation(equationEid, null);

            _pointGraph.AddPoint(fromPoint);
            _pointGraph.AddPoint(toPoint);

            Assert.Throws(typeof(KeyNotFoundException), () => _pointGraph.AddEquationRelationship(fromPoint, toPoint, equation));
        }

        [Test]
        public void AddEquationRelationship_ToDoesntExist_ThrowsException()
        {
            int fromEid = 0;
            int toEid = 1;
            int equationEid = 2;
            var fromPoint = A.Fake<IPoint>();
            A.CallTo(() => fromPoint.Eid).Returns(fromEid);
            var toPoint = A.Fake<IPoint>();
            A.CallTo(() => fromPoint.Eid).Returns(toEid);
            var equation = new PointEquation(equationEid, null);

            _pointGraph.AddPoint(fromPoint);
            _pointGraph.AddEquation(equation);

            Assert.Throws(typeof(KeyNotFoundException), () => _pointGraph.AddEquationRelationship(fromPoint, toPoint, equation));
        }

        [Test]
        public void AddEquationRelationship_InsertsIntoUnderlyingGraph()
        {
            int fromEid = 0;
            int toEid = 1;
            int equationEid = 2;
            var fromPoint = A.Fake<IPoint>();
            A.CallTo(() => fromPoint.Eid).Returns(fromEid);
            var toPoint = A.Fake<IPoint>();
            A.CallTo(() => fromPoint.Eid).Returns(toEid);
            var equation = new PointEquation(equationEid, null);

            _pointGraph.AddPoint(fromPoint);
            _pointGraph.AddPoint(toPoint);
            _pointGraph.AddEquation(equation);

            _pointGraph.AddEquationRelationship(fromPoint, toPoint, equation);

            A.CallTo(() => _underlyingDirectedGraph.AddDirectedEdge(fromPoint, toPoint, equation)).MustHaveHappened();
        }

        [Test]
        public void AddEquationRelationship_RaisesToPointUpdated()
        {
            int fromEid = 0;
            int toEid = 1;
            int equationEid = 2;
            var fromPoint = A.Fake<IPoint>();
            A.CallTo(() => fromPoint.Eid).Returns(fromEid);
            var toPoint = A.Fake<IPoint>();
            A.CallTo(() => fromPoint.Eid).Returns(toEid);
            var equation = new PointEquation(equationEid, null);

            _pointGraph.AddPoint(fromPoint);
            _pointGraph.AddPoint(toPoint);
            _pointGraph.AddEquation(equation);
            toPoint.MonitorEvents();

            _pointGraph.AddEquationRelationship(fromPoint, toPoint, equation);

            A.CallTo(() => toPoint.Update()).MustHaveHappened();
        }

        [Test]
        public void DeleteEquationRelationship_DeletesFromUnderlyingGraph()
        {
            int fromEid = 0;
            int toEid = 1;
            int equationEid = 2;
            var fromPoint = A.Fake<IPoint>();
            A.CallTo(() => fromPoint.Eid).Returns(fromEid);
            var toPoint = A.Fake<IPoint>();
            A.CallTo(() => fromPoint.Eid).Returns(toEid);
            var equation = new PointEquation(equationEid, null);

            _pointGraph.AddPoint(fromPoint);
            _pointGraph.AddPoint(toPoint);
            _pointGraph.AddEquation(equation);

            _pointGraph.AddEquationRelationship(fromPoint, toPoint, equation);
            _pointGraph.DeleteEquationRelationship(fromPoint, toPoint, equation);

            A.CallTo(() => _underlyingDirectedGraph.RemoveDirectedEdge(fromPoint, toPoint, equation)).MustHaveHappened();
        }
    }
}
