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
    class PointUpdateStrategyTests
    {
        private PointUpdateStrategy _pointUpdateStrategy;
        private IDirectedGraph<IPoint, PointEquation> _underlyingDirectedGraph;
        private IEquationCalculateStrategy _equationCalculateStrategy;

        [SetUp]
        public void Setup()
        {
            _underlyingDirectedGraph = A.Fake<IDirectedGraph<IPoint, PointEquation>>();
            _equationCalculateStrategy = A.Fake<IEquationCalculateStrategy>();
            _pointUpdateStrategy = new PointUpdateStrategy(_underlyingDirectedGraph, _equationCalculateStrategy);
        }

        [Test]
        public void UpdatePointOutputChain_NoParentsOrChildren_OutputIsValue()
        {
            var value = "test2";
            var eid = 1;
            var point = A.Fake<IPoint>();
            A.CallTo(() => point.Eid).Returns(eid);
            A.CallTo(() => point.Value).Returns(value);

            _pointUpdateStrategy.UpdatePointOutputChain(point);

            A.CallToSet(() => point.Output).To(value).MustHaveHappened();
        }

        [Test]
        public void UpdatePointOutputChain_HasChild_ChildUpdatedToo()
        {
            var value = "test2";
            var eid = 1;
            var point = A.Fake<IPoint>();
            A.CallTo(() => point.Eid).Returns(eid);
            A.CallTo(() => point.Value).Returns(value);

            var childValue = "test4";
            var eid2 = 2;
            var childPoint = A.Fake<IPoint>();
            A.CallTo(() => childPoint.Eid).Returns(eid2);
            A.CallTo(() => childPoint.Value).Returns(childValue);

            A.CallTo(() => _underlyingDirectedGraph.GetChildRelationOf(point))
                .Returns(new List<Tuple<IPoint, PointEquation>>
                {
                    new Tuple<IPoint, PointEquation>(childPoint, null)
                });

            _pointUpdateStrategy.UpdatePointOutputChain(point);

            A.CallToSet(() => point.Output).To(value).MustHaveHappened();
            A.CallToSet(() => childPoint.Output).To(childValue).MustHaveHappened();
        }

        [Test]
        public void UpdatePointOutputChain_HasParent_OutputCalculatedViaStrategy()
        {
            var value = "test2";
            var eid = 1;
            var point = A.Fake<IPoint>();
            A.CallTo(() => point.Eid).Returns(eid);
            var parentValue = "test4";
            var eid2 = 2;
            var parentPoint = A.Fake<IPoint>();

            var parentEquationValue = "1+1";
            var parentEquation = new PointEquation(5, parentEquationValue);

            var correctOutput = "output";

            var parentRelations = new List<Tuple<IPoint, PointEquation>>
            {
                new Tuple<IPoint, PointEquation>(parentPoint, parentEquation)
            };

            A.CallTo(() => _underlyingDirectedGraph.GetParentRelationOf(point))
                .Returns(parentRelations);
            A.CallTo(() => _equationCalculateStrategy.CalculateEquation(point, parentRelations)).Returns(correctOutput);


            _pointUpdateStrategy.UpdatePointOutputChain(point);

            A.CallToSet(() => point.Output).To(correctOutput).MustHaveHappened();
        }

        [Test]
        public void UpdatePointOutputChain_HasCircularReference_ThrowsException()
        {
            var value = "test2";
            var eid = 1;
            var point = A.Fake<IPoint>();
            A.CallTo(() => point.Eid).Returns(eid);
            var childValue = "test4";
            var eid2 = 2;
            var childPoint = A.Fake<IPoint>();
            A.CallTo(() => childPoint.Eid).Returns(eid2);

            A.CallTo(() => _underlyingDirectedGraph.GetChildRelationOf(point))
                .Returns(new List<Tuple<IPoint, PointEquation>>
                {
                    new Tuple<IPoint, PointEquation>(childPoint, null)
                });

            A.CallTo(() => _underlyingDirectedGraph.GetChildRelationOf(childPoint))
                .Returns(new List<Tuple<IPoint, PointEquation>>
                {
                    new Tuple<IPoint, PointEquation>(point, null)
                });

            Assert.Throws(typeof(CircularReferenceException), () => _pointUpdateStrategy.UpdatePointOutputChain(point));
        }

        [Test]
        public void InsertEquationBindingMustBeAbleToBeUndoneFailFromCircularReference()
        {
            Assert.That(true == false);
        }
    }
}
