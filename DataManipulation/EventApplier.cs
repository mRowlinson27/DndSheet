using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomForms.API;
using DataManipulation.API;

namespace DataManipulation
{
    public class EventApplier<T> : IEventApplier<T>
    {
        public T Apply(T input, T style)
        {
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
    }
}
