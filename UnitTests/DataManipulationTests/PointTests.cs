using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API;
using DataManipulation.API.DTOs;
using DataManipulation.API.Point;
using DataManipulation.Point;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    public class PointTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void NewPoint_ValueCorrect()
        {
            var correctValue = "test";
            var pvalue = new PointValue(1, "", correctValue);

            var point = new Point(2, pvalue);

            point.Output.Should().Be(correctValue);
        }

        [Test]
        public void UpdateValue_ValueCorrect()
        {
            var correctValue = "test";
            var pvalue = new PointValue(1, "", "");
            var point = new Point(2, pvalue);

            point.UpdateValue(correctValue);

            point.Output.Should().Be(correctValue);
        }

        [Test]
        public void UpdateValue_TriggersUpdated()
        {
            var value = "test";
            var pvalue = new PointValue(1, "", "");
            var point = new Point(2, pvalue);
            point.MonitorEvents();

            point.UpdateValue(value);

            point.ShouldRaise("Updated");
        }

        [Test]
        public void UpdateValue_DoesNotTriggersUpdatedIfSameResult()
        {
            var value = "test";
            var pvalue = new PointValue(1, "", value);
            var point = new Point(2, pvalue);
            point.MonitorEvents();

            point.UpdateValue(value);

            point.ShouldNotRaise("Updated");
        }

        [Test]
        public void AddSubscriber_RecalculatesOutput()
        {
            var value = "test";
            var dataType = "type";
            var pvalue = new PointValue(1, dataType, value);
            var point = new Point(2, pvalue);
            var equation = A.Fake<IPointEquation>();
            A.CallTo(() => equation.Evaluate(value, dataType)).Returns(value);

            point.SubscribeTo(equation);

            point.Output.Should().Be(value);
        }

        [Test]
        public void AddSubscriber_TriggersUpdatedIfDifferentResult()
        {
            var value1 = "test";
            var value2 = "test2";
            var dataType = "type";
            var pvalue = new PointValue(1, dataType, value1);
            var point = new Point(2, pvalue);
            var equation = A.Fake<IPointEquation>();
            A.CallTo(() => equation.Evaluate(value1, dataType)).Returns(value2);
            point.MonitorEvents();

            point.SubscribeTo(equation);

            point.ShouldRaise("Updated");
        }

        [Test]
        public void AddSubscriber_DoesNotTriggersUpdatedIfSameResult()
        {
            var value = "test";
            var dataType = "type";
            var pvalue = new PointValue(1, dataType, value);
            var point = new Point(2, pvalue);
            var equation = A.Fake<IPointEquation>();
            A.CallTo(() => equation.Evaluate(value, dataType)).Returns(value);
            point.MonitorEvents();

            point.SubscribeTo(equation);

            point.ShouldNotRaise("Updated");
        }

        [Test]
        public void AddSubscriber_SameSubscriber_ThrowsException()
        {
            var value = "test";
            var dataType = "type";
            var pvalue = new PointValue(1, dataType, value);
            var point = new Point(2, pvalue);
            var equation = A.Fake<IPointEquation>();
            A.CallTo(() => equation.Evaluate(value, dataType)).Returns(value);
            A.CallTo(() => equation.Eid).Returns(3);

            point.SubscribeTo(equation);
            Assert.Throws(typeof(ArgumentException),() => point.SubscribeTo(equation));
        }

        [Test]
        public void AddSubscriber_UpdateEquationUpdatesPoint()
        {
            var value1 = "test1";
            var dataType = "type";
            var value2 = "test2";
            var pvalue = new PointValue(1, dataType, value1);
            var point = new Point(2, pvalue);
            var equation = A.Fake<IPointEquation>();
            A.CallTo(() => equation.Evaluate(value1, dataType)).Returns(value1);
            A.CallTo(() => equation.Eid).Returns(3);
            point.SubscribeTo(equation);
            A.CallTo(() => equation.Evaluate(value1, dataType)).Returns(value2);

            equation.Updated += Raise.WithEmpty();

            point.Output.Should().Be(value2);
        }

        [Test]
        public void UnSubscribeTo_RecalculatesWithoutSubscriber()
        {
            var value1 = "test";
            var value2 = "test2";
            var dataType = "type";
            var pvalue = new PointValue(1, dataType, value1);
            var point = new Point(2, pvalue);
            var equation = A.Fake<IPointEquation>();
            A.CallTo(() => equation.Evaluate(value1, dataType)).Returns(value2);
            point.SubscribeTo(equation);

            point.UnSubscribeTo(equation);

            point.Output.Should().Be(value1);
        }

        [Test]
        public void UnSubscribeTo_TriggersUpdated()
        {
            var value1 = "test";
            var value2 = "test2";
            var dataType = "type";
            var pvalue = new PointValue(1, dataType, value1);
            var point = new Point(2, pvalue);
            var equation = A.Fake<IPointEquation>();
            A.CallTo(() => equation.Evaluate(value1, dataType)).Returns(value2);
            point.SubscribeTo(equation);
            point.MonitorEvents();

            point.UnSubscribeTo(equation);

            point.ShouldRaise("Updated");
        }

        [Test]
        public void UnSubscribeTo_NoLongerListensToEquation()
        {
            var value1 = "test";
            var dataType = "type";
            var pvalue = new PointValue(1, dataType, value1);
            var point = new Point(2, pvalue);
            var equation = A.Fake<IPointEquation>();
            var equation2 = A.Fake<IPointEquation>();
            A.CallTo(() => equation.Eid).Returns(3);
            point.SubscribeTo(equation);
            point.UnSubscribeTo(equation);
            point.SubscribeTo(equation2);

            equation.Updated += Raise.WithEmpty();
            
            A.CallTo(() => equation2.Evaluate(value1, dataType)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void IntegrationTestForMemoryLeaks()
        {
            Assert.That(true == false);
        }
    }
}
