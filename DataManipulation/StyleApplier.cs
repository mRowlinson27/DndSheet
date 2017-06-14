using System;
using System.Collections.Generic;
using CustomForms.API;

namespace DataManipulation
{
    public class StyleApplier<T> : IStyleApplier<T>
    {

        public T Apply(T input, T style)
        {
            var output = input;

            var propertyInfos = style.GetType().GetProperties();

            foreach (var propertyInfo in propertyInfos)
            {
                var outputInfo = output.GetType().GetProperty(propertyInfo.Name);

                if (outputInfo != null && !IsNullOrDefault(propertyInfo.GetValue(style)))
                {
                    outputInfo.SetValue(output, Convert.ChangeType(propertyInfo.GetValue(style), propertyInfo.PropertyType), null);
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            return output;
        }

        private bool IsNullOrDefault<Tin>(Tin argument)
        {
            if (argument == null || object.Equals(argument, default(Tin)))
            {
                return true;
            }

            var methodType = typeof(Tin);
            if (Nullable.GetUnderlyingType(methodType) != null)
            {
                return false;
            }

            var argumentType = argument.GetType();
            if (argumentType.IsValueType && argumentType != methodType)
            {
                var obj = Activator.CreateInstance(argument.GetType());
                return obj.Equals(argument);
            }

            return false;
        }

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
