using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManipulation;
using DataManipulation.DTO;
using DataManipulation.Interfaces;
using FakeItEasy;
using NUnit.Framework;
using Utilities.API;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    public class PointUpdateSubscriberTests
    {
        private PointUpdateSubscriber _pointUpdateSubscriber;
        private IPointUpdateStrategy _pointUpdateStrategy;

        [SetUp]
        public void Setup()
        {
            _pointUpdateStrategy = A.Fake<IPointUpdateStrategy>();
            _pointUpdateSubscriber = new PointUpdateSubscriber(_pointUpdateStrategy);
        }

        [Test]
        public void SubscribeToPoint_CallsStrategyUpdate()
        {
            var point = A.Fake<IPoint>();

            _pointUpdateSubscriber.SubscribeToPoint(point);

            A.CallTo(() => _pointUpdateStrategy.UpdatePointOutputChain(point)).MustHaveHappened();
        }

        [Test]
        public void SubscribeToPoint_CallsStrategyOnEvent()
        {
            var point = A.Fake<IPoint>();

            _pointUpdateSubscriber.SubscribeToPoint(point);

            point.Updated += Raise.WithEmpty();

            A.CallTo(() => _pointUpdateStrategy.UpdatePointOutputChain(point)).MustHaveHappened(Repeated.Exactly.Twice);
        }

        [Test]
        public void UnSubscribeToPoint_NoLongerCallsStrategyOnEvent()
        {
            var point = A.Fake<IPoint>();

            _pointUpdateSubscriber.SubscribeToPoint(point);
            _pointUpdateSubscriber.UnSubscribeToPoint(point);

            point.Value = "test3";

            A.CallTo(() => _pointUpdateStrategy.UpdatePointOutputChain(point)).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
