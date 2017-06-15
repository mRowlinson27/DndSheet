using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataManipulation;
using NUnit.Framework;

namespace UnitTests.DataManipulationTests
{
    [TestFixture]
    public class EventApplierTests
    {
        private EventApplier<IGenericEvents> _eventApplier;

        [SetUp]
        public void Setup()
        {
            _eventApplier = new EventApplier<IGenericEvents>();
        }

        [Test]
        public void Event_SubScriberCopied()
        {
            var original = new GenericEvent1();
            var eventStyle = new GenericEvent1();
            eventStyle.Event += DoSomething;

            _eventApplier.Apply(original, eventStyle);

            eventStyle.OnEvent();
            original.OnEvent();
        }

        private void DoSomething(object sender, EventArgs e)
        {
            Console.WriteLine("Test");
        }
    }

    internal interface IGenericEvents
    {
        event EventHandler Event;
        event EventHandler Click;
    }

    internal class GenericEvent1 : IGenericEvents
    {
        public event EventHandler Event;
        public event EventHandler Click;

        public void OnEvent()
        {
            Event.Invoke(null, null);
        }
    }

    internal class GenericEvent2 : IGenericEvents
    {
        public event EventHandler Event;
        public event EventHandler Click;
    }
}
