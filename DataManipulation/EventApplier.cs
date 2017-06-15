using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataManipulation.API;

namespace DataManipulation
{
    public class EventApplier<T> : IEventApplier<T>
    {
        public T Apply(T input, T style)
        {
            RemoveEventSubscriptions(input);
            var output = input;
            var styleEvents = style.GetType().GetEvents();

            foreach (var styleEvent in styleEvents)
            {
                var memberInfo = style.GetType()
                    .GetField(styleEvent.Name, BindingFlags.Instance | BindingFlags.NonPublic);
                if (memberInfo != null)
                {
                    var eventDelegate = (MulticastDelegate) memberInfo
                        .GetValue(style);

                    if (eventDelegate != null)
                    {
                        foreach (var handler in eventDelegate.GetInvocationList())
                        {
                            var outputEvent = output.GetType().GetEvent(styleEvent.Name);
                            if (outputEvent != null)
                            {
                                outputEvent.AddEventHandler(output, handler);
                            }
                        }
                    }
                }
            }
            return output;
        }

        private void RemoveEventSubscriptions(T input)
        {
            var styleEvents = input.GetType().GetEvents();
            foreach (var styleEvent in styleEvents)
            {
                var memberInfo = input.GetType()
                    .GetField(styleEvent.Name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                if (memberInfo != null)
                {
                    var eventDelegate = (MulticastDelegate)memberInfo
                        .GetValue(input);

                    if (eventDelegate != null)
                    {
                        foreach (var handler in eventDelegate.GetInvocationList())
                        {
                            styleEvent.RemoveEventHandler(input, handler);
                        }
                    }
                }
            }
        }
    }
}
