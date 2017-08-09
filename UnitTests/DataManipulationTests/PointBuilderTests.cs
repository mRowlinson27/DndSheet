using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation.API.Point;
using DataManipulation.Point;
using FakeItEasy;
using NUnit.Framework;
using SqlDatabase.API.DTO;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    public class PointBuilderTests
    {
        private PointBuilder _pointBuilder;
        private IPointFactory _pointFactory;
        private IPointCalculateStrategy _simpleCalculateStrategy;

        [SetUp]
        public void Setup()
        {
            _simpleCalculateStrategy = A.Fake<IPointCalculateStrategy>();
            _pointBuilder = new PointBuilder(_pointFactory, _simpleCalculateStrategy);
        }

        [Test]
        public void Build_RegularPoint()
        {

        }
    }
}
