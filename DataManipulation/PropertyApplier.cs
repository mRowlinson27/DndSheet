using System;
using DataManipulation.API;

namespace DataManipulation
{
    public class PropertyApplier<T> : IPropertyApplier<T>
    {
        public T Apply<T2>(T input, T2 style) where T2 : IPropertyChangedChecker
        {
            var output = input;

            var propertyInfos = style.GetType().GetProperties();

            foreach (var propertyInfo in propertyInfos)
            {
                var outputInfo = output.GetType().GetProperty(propertyInfo.Name);

                if (outputInfo != null )
                {
                    if (style.HasPropertyChanged(propertyInfo.Name))
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
    }
}
