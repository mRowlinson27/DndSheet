using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataManipulation;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    public class EventApplierTests
    {
        private EventApplier<IGenericEvents> _eventApplier;
        private IFlag _flag;

        [SetUp]
        public void Setup()
        {
            _flag = A.Fake<IFlag>();
            _eventApplier = new EventApplier<IGenericEvents>();
        }

        [Test]
        public void Apply_OneEventSubscribed_SubScriberCopied()
        {
            var original = new GenericEvent1();
            var eventStyle = new GenericEvent1();
            eventStyle.Event += DoSomething;

            _eventApplier.Apply(original, eventStyle);
            original.OnEvent();

            A.CallToSet(() => _flag.Flag).To(true).MustHaveHappened();
        }

        [Test]
        public void Apply_EventSubscribedTwice_BothSubScriberCopied()
        {
            var original = new GenericEvent1();
            var eventStyle = new GenericEvent1();
            eventStyle.Event += DoSomething;
            eventStyle.Event += DoSomething;

            _eventApplier.Apply(original, eventStyle);
            original.OnEvent();

            A.CallToSet(() => _flag.Flag).To(true).MustHaveHappened(Repeated.Exactly.Twice);
        }

        [Test]
        public void Apply_NoEventSubscrition_NoExceptions()
        {
            var original = new GenericEvent1();
            var eventStyle = new GenericEvent1();

            _eventApplier.Apply(original, eventStyle);
            original.OnEvent();
        }

        [Test]
        public void Apply_OriginalEventSubscrition_SubscriptionRemoved()
        {
            var original = new GenericEvent1();
            var eventStyle = new GenericEvent1();
            original.Event += DoSomething;

            _eventApplier.Apply(original, eventStyle);
            original.OnEvent();

            A.CallToSet(() => _flag.Flag).To(true).MustNotHaveHappened();
        }

        private void DoSomething(object sender, EventArgs e)
        {
            _flag.Flag = true;
        }
    }

    public interface IFlag
    {
        bool Flag { get; set; }
    }

    internal interface IGenericEvents
    {
        event EventHandler Event;
    }

    internal class GenericEvent1 : IGenericEvents
    {
        public event EventHandler Event;

        public void OnEvent()
        {
            if (Event != null)
            {
                Event.Invoke(null, null);
            }
        }
    }

    internal class GenericEvent2 : IGenericEvents
    {
        public event EventHandler Event;
        public event EventHandler Click;

        public void OnEvent()
        {
            if (Event != null)
            {
                Event.Invoke(null, null);
            }
        }

        public void OnClick()
        {
            if (Event != null)
            {
                Event.Invoke(null, null);
            }
        }
    }
}
