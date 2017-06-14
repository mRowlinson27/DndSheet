using System;
using System.Collections.Generic;
using CustomForms.API;

namespace DataManipulation
{
    public class StyleApplier<T> : IStyleApplier<T>
    {
        public T Apply(T input, Dictionary<string, object> dictionary)
        {
            var output = input;
            foreach (var kvp in dictionary)
            {
                var propertyInfo = output.GetType().GetProperty(kvp.Key);

                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(output, Convert.ChangeType(kvp.Value, propertyInfo.PropertyType), null);
                }
                else
                {
                    return default(T);
                }
            }

            return output;
        }
    }
}
