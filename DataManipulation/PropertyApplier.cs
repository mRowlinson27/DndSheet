using System;
using CustomFormManipulation.API;
using CustomForms.API;
using DataManipulation.API;

namespace CustomFormManipulation
{
    public class PropertyApplier<T> : IPropertyApplier<T>
    {
        public T Apply(T input, T style)
        {
            var output = input;

            var propertyInfos = style.GetType().GetProperties();

            foreach (var propertyInfo in propertyInfos)
            {
                var outputInfo = output.GetType().GetProperty(propertyInfo.Name);

                if (outputInfo != null )
                {
                    if (!IsNullOrDefault(propertyInfo.GetValue(style)))
                    {
                        outputInfo.SetValue(output,
                            Convert.ChangeType(propertyInfo.GetValue(style), propertyInfo.PropertyType), null);
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            return output;
        }

        private bool IsNullOrDefault<TIn>(TIn argument)
        {
            if (argument == null || object.Equals(argument, default(TIn)))
            {
                return true;
            }

            var methodType = typeof(TIn);
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
    }
}
