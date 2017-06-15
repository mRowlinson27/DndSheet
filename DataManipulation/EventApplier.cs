using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataManipulation
{
    public class EventApplier<T>
    {
        public T Apply(T input, T style)
        {
            var output = input;
            var styleEvents = style.GetType().GetEvents();

            foreach (var styleEvent in styleEvents)
            {
                Console.WriteLine(styleEvent.Name);
                //var test = typeof(T).GetField("events", BindingFlags.NonPublic | BindingFlags.Instance);
                //styleEvent.GetRaiseMethod().CreateDelegate()
                var eventDelegate =
                    (MulticastDelegate)
                        style.GetType()
                            .GetField(styleEvent.Name, BindingFlags.Instance | BindingFlags.NonPublic)
                            .GetValue(style);
                //https://stackoverflow.com/questions/198543/how-do-i-raise-an-event-via-reflection-in-net-c
                eventDelegate.Method.Invoke(eventDelegate.GetInvocationList()[0], new []{style, (object) default(T)});

                var ctrlEventsCollection = (EventHandlerList)typeof(T)
                                        .GetProperty("Event", BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance)
                                        .GetValue(style, null);

                var outputEvent = output.GetType().GetEvent(styleEvent.Name);
                if (outputEvent != null)
                {
                    var test = styleEvent.GetAddMethod(true);
//                    test.CreateDelegate(EventHandler, this);
                    outputEvent.AddEventHandler(output, new EventHandler((sender, args) => Console.WriteLine("meow")));
//                    outputEvent.AddEventHandler(output, Delegate.CreateDelegate(typeof(EventHandler), test));
                }
            }

            return output;
        }
    }
}
