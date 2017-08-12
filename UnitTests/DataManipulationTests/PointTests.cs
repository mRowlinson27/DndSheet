using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation;
using DataManipulation.DTO;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    class PointTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Getters_ReturnPointValueParameters()
        {
            var dataType = "dataType";
            var value = "value";
            var pointValue = new PointValue(1, dataType, value);

            var point = new Point(2, pointValue);

            point.DataType.Should().Be(dataType);
            point.Value.Should().Be(value);
        }

        [Test]
        public void SetDataType_RaisesUpdated()
        {
            var dataType = "dataType";
            var value = "value";
            var pointValue = new PointValue(1, dataType, value);
            var point = new Point(2, pointValue);

            point.MonitorEvents();
            point.DataType = "newDataType";

            point.ShouldRaise("Updated");
        }

        [Test]
        public void SetValue_RaisesUpdated()
        {
            var dataType = "dataType";
            var value = "value";
            var pointValue = new PointValue(1, dataType, value);
            var point = new Point(2, pointValue);

            point.MonitorEvents();
            point.Value = "newValue";

            point.ShouldRaise("Updated");
        }

        [Test]
        public void Update_RaisesUpdated()
        {
            var dataType = "dataType";
            var value = "value";
            var pointValue = new PointValue(1, dataType, value);
            var point = new Point(2, pointValue);

            point.MonitorEvents();
            point.Update();

            point.ShouldRaise("Updated");
        }
    }
}
