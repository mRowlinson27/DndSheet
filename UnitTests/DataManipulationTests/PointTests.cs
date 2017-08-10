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
            A.CallTo(() => equation.Evaluate(A<EquationRequest>.That.Matches(x => x.Value == value && x.DataType == dataType && x.SubscriberEid == 3))).Returns(value);

            point.SubscribeTo(3, equation);

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
            A.CallTo(() => equation.Evaluate(A<EquationRequest>.That.Matches(x => x.Value == value1 && x.DataType == dataType && x.SubscriberEid == 3))).Returns(value2);
            point.MonitorEvents();

            point.SubscribeTo(3, equation);

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
            A.CallTo(() => equation.Evaluate(A<EquationRequest>.That.Matches(x => x.Value == value && x.DataType == dataType && x.SubscriberEid == 3))).Returns(value);
            point.MonitorEvents();

            point.SubscribeTo(3, equation);

            point.ShouldNotRaise("Updated");
        }

        [Test]
        public void AddSubscriber_SameSubscriber_ThrowsExceptionIfSameUID()
        {
            var value = "test";
            var dataType = "type";
            var pvalue = new PointValue(1, dataType, value);
            var point = new Point(2, pvalue);
            var equation = A.Fake<IPointEquation>();
            A.CallTo(() => equation.Evaluate(A<EquationRequest>.That.Matches(x => x.Value == value && x.DataType == dataType && x.SubscriberEid == 3))).Returns(value);
            A.CallTo(() => equation.Eid).Returns(3);

            point.SubscribeTo(3, equation);
            Assert.Throws(typeof(ArgumentException),() => point.SubscribeTo(3, equation));
        }

        [Test]
        public void AddSubscriber_SameSubscriber_DoesNotThrowsExceptionIfDifferentUID()
        {
            var value = "test";
            var dataType = "type";
            var pvalue = new PointValue(1, dataType, value);
            var point = new Point(2, pvalue);
            var equation = A.Fake<IPointEquation>();
            A.CallTo(() => equation.Evaluate(A<EquationRequest>.That.Matches(x => x.Value == value && x.DataType == dataType && x.SubscriberEid == 3))).Returns(value);
            A.CallTo(() => equation.Eid).Returns(3);

            point.SubscribeTo(3, equation);
            point.SubscribeTo(4, equation);
        }

        [Test]
        public void AddSubscriber_ThrowsExceptionIfItself()
        {
            var value = "test";
            var dataType = "type";
            var pvalue = new PointValue(1, dataType, value);
            var point = new Point(2, pvalue);
            var equation = A.Fake<IPointEquation>();
            A.CallTo(() => equation.Evaluate(A<EquationRequest>.That.Matches(x => x.Value == value && x.DataType == dataType && x.SubscriberEid == 3))).Returns(value);
            A.CallTo(() => equation.Eid).Returns(3);

            Assert.Throws(typeof(ArgumentException), () => point.SubscribeTo(2, equation));
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
            A.CallTo(() => equation.Evaluate(A<EquationRequest>.That.Matches(x => x.Value == value1 && x.DataType == dataType && x.SubscriberEid == 4))).Returns(value1);
            A.CallTo(() => equation.Eid).Returns(3);
            point.SubscribeTo(4, equation);
            A.CallTo(() => equation.Evaluate(A<EquationRequest>.That.Matches(x => x.Value == value1 && x.DataType == dataType && x.SubscriberEid == 4))).Returns(value2);

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
            A.CallTo(() => equation.Evaluate(A<EquationRequest>.That.Matches(x => x.Value == value1 && x.DataType == dataType && x.SubscriberEid == 4))).Returns(value2);
            point.SubscribeTo(4, equation);

            point.UnSubscribeTo(4, equation);

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
            A.CallTo(() => equation.Evaluate(A<EquationRequest>.That.Matches(x => x.Value == value1 && x.DataType == dataType && x.SubscriberEid == 4))).Returns(value2);
            point.SubscribeTo(4, equation);
            point.MonitorEvents();

            point.UnSubscribeTo(4, equation);

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
            A.CallTo(() => equation2.Eid).Returns(4);

            point.SubscribeTo(3, equation);
            point.UnSubscribeTo(3, equation);
            point.SubscribeTo(4, equation2);

            A.CallTo(() => equation2.Evaluate(A<EquationRequest>.Ignored)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Test]
        public void IntegrationTestForMemoryLeaks()
        {
            Assert.That(true == false);
        }
    }
}
