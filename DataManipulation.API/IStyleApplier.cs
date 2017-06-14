using System.Collections.Generic;

namespace CustomForms.API
{
    public interface IStyleApplier<T>
    {
        T Apply(T input, Dictionary<string, object> dictionary);
    }
}
